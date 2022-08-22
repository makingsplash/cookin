using System;
using Core.Game.Signals;
using Core.UI.Elements;
using Core.UI.Elements.Base;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Core.UI
{
    public class UIManager : IDisposable
    {
        private DiContainer Container { get; }
        private UIRoot UIRoot { get; }
        private SignalBus SignalBus { get; }

        public UIManager(DiContainer container, UIRoot uiRoot, SignalBus signalBus)
        {
            Container = container;
            UIRoot = uiRoot;
            SignalBus = signalBus;

            SignalBus.Subscribe<ShowPopupSignal>(CreateUIViewPresenter);
        }

        private void CreateUIViewPresenter(ShowPopupSignal signal)
        {
            var presenter = Container.Instantiate(signal.PresenterType) as UIViewBasePresenter;

            CreateUIView(presenter);
        }

        private void CreateUIView(UIViewBasePresenter presenter)
        {
            Addressables.InstantiateAsync(presenter.PrefabPath, UIRoot.transform.position, Quaternion.identity, UIRoot.transform).Completed +=
                handle =>
                {
                    UIViewBase viewBase = handle.Result.GetComponent<UIViewBase>();
                    Container.Inject(viewBase);
                    presenter.SetupView(viewBase);
                };
        }

        public void Dispose()
        {
            SignalBus.Unsubscribe<ShowPopupSignal>(CreateUIViewPresenter);
        }
    }
}