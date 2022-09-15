using System;
using Core.Consumables;
using Core.Game.Signals;
using UnityEngine;
using Zenject;

namespace Core.Transactions
{
    public class TransactionManager : IInitializable, IDisposable, ISignalListener
    {
        private SignalBus SignalBus { get; }
        private ConsumablesManager ConsumablesManager { get; }


        public TransactionManager(SignalBus signalBus, ConsumablesManager consumablesManager)
        {
            SignalBus = signalBus;
            ConsumablesManager = consumablesManager;
        }

        public void SignalsSubscribe()
        {
            SignalBus.Subscribe<TransactionSignal>(ProcessTransaction);
        }

        public void SignalsUnsubscribe()
        {
            SignalBus.Unsubscribe<TransactionSignal>(ProcessTransaction);
        }

        private void ProcessTransaction(TransactionSignal signal)
        {
            // check network, make purchase, etc
            Debug.Log($"[{nameof(TransactionManager)}]: Transaction of {signal.Transaction.Amount} {signal.Transaction.ConsumableType}s");


            ConsumableType consumableType = signal.Transaction.ConsumableType;
            int changeAmount = signal.Transaction.Amount;

            int oldAmount = ConsumablesManager.GetConsumableAmount(consumableType);
            int newAmount = oldAmount + changeAmount;

            ConsumablesManager.SetConsumableAmount(consumableType, newAmount);

            SignalBus.TryFire(new ConsumableAmountChangedSignal(consumableType, oldAmount, newAmount));
        }

        public void Initialize()
        {
            SignalsSubscribe();
        }

        public void Dispose()
        {
            SignalsUnsubscribe();
        }
    }
}