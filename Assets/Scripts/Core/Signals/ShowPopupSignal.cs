using System;

namespace Core.Game.Signals
{
    public class ShowPopupSignal
    {
        public Type PresenterType { get; }

        public ShowPopupSignal(Type presenterType)
        {
            PresenterType = presenterType;
        }
    }
}