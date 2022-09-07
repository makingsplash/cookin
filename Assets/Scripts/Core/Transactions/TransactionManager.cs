using System;
using Core.Consumables;
using Core.Game.Signals;
using Core.PlayerProfile;
using UnityEngine;
using Zenject;

namespace Core.Transactions
{
    public class TransactionManager : IInitializable, IDisposable, ISignalListener
    {
        private SignalBus SignalBus { get; }
        private ProfileManager ProfileManager { get; }


        public TransactionManager(SignalBus signalBus, ProfileManager profileManager)
        {
            SignalBus = signalBus;
            ProfileManager = profileManager;
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


            var consumableType = signal.Transaction.ConsumableType;
            var changeAmount = signal.Transaction.Amount;

            var oldAmount = ProfileManager.GetConsumableAmount(consumableType);
            var newAmount = oldAmount + changeAmount;

            ProfileManager.SetConsumableAmount(consumableType, newAmount);

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