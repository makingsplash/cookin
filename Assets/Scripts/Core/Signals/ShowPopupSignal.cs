using System;

namespace Core.Signals
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