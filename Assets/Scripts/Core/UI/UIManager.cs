using System;
using Core.Game.Signals;
using Core.UI.Elements;
using Core.UI.Elements.Base;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Core.UI
{
    public class UIManager : IInitializable, ISignalListener, IDisposable
    {
        private DiContainer Container { get; }

        private UIRoot UIRoot { get; }

        private SignalBus SignalBus { get; }

        public UIManager(DiContainer container, SignalBus signalBus, UIRoot uiRoot)
        {
            Container = container;
            SignalBus = signalBus;
            UIRoot = uiRoot;
        }

        public void Initialize()
        {
            SignalsSubscribe();
        }

        public void SignalsSubscribe()
        {
            SignalBus.Subscribe<ShowPopupSignal>(CreateUIViewPresenter);
        }

        public void SignalsUnsubscribe()
        {
            SignalBus.Unsubscribe<ShowPopupSignal>(CreateUIViewPresenter);
        }

        public AsyncOperationHandle CreateUIViewPresenter<T>()
        {
            var presenter = Container.Instantiate(typeof(T)) as UIViewBasePresenter;

            AsyncOperationHandle asyncOperationHandle = CreateUIView(presenter);

            return asyncOperationHandle;
        }

        private void CreateUIViewPresenter(ShowPopupSignal signal)
        {
            var presenter = Container.Instantiate(signal.PresenterType) as UIViewBasePresenter;

            CreateUIView(presenter);
        }

        private AsyncOperationHandle<GameObject> CreateUIView(UIViewBasePresenter presenter)
        {
            AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.InstantiateAsync(presenter.PrefabPath, UIRoot.transform.position, Quaternion.identity, UIRoot.transform);

            asyncOperationHandle.Completed +=
                handle =>
                {
                    UIViewBase viewBase = handle.Result.GetComponent<UIViewBase>();
                    Container.Inject(viewBase);
                    presenter.SetView(viewBase);
                    presenter.InitializeView();
                    viewBase.Show();
                };

            return asyncOperationHandle;
        }

        public void Dispose()
        {
            SignalsUnsubscribe();
        }
    }
}