namespace Core.Game.Signals
{
    public interface ISignalListener
    {
        public void SignalsSubscribe();
        public void SignalsUnsubscribe();
    }
}