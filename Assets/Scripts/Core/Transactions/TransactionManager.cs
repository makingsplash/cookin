using System;
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
            Debug.Log($"[{nameof(TransactionManager)}]: Transaction of {signal.Transaction.Amount} {signal.Transaction.ConsumableType}s");
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