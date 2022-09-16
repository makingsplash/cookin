using System;
using Core.Signals;
using Core.UI.Elements;
using Core.UI.Elements.Base;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Core.UI
{
    public class UIManager : IInitializable, IDisposable, ISignalListener
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
            ViewPresenterBase presenter = Container.Instantiate(typeof(T)) as ViewPresenterBase;

            AsyncOperationHandle asyncOperationHandle = CreateUIView(presenter);

            return asyncOperationHandle;
        }

        private void CreateUIViewPresenter(ShowPopupSignal signal)
        {
            ViewPresenterBase presenter = Container.Instantiate(signal.PresenterType) as ViewPresenterBase;

            CreateUIView(presenter);
        }

        private AsyncOperationHandle<GameObject> CreateUIView(ViewPresenterBase viewPresenter)
        {
            var asyncOperationHandle = Addressables.InstantiateAsync(viewPresenter.PrefabPath, UIRoot.transform.position, Quaternion.identity, UIRoot.transform);

            asyncOperationHandle.Completed +=
                handle =>
                {
                    ViewBase view = handle.Result.GetComponent<ViewBase>();
                    Container.Inject(view);

                    viewPresenter.View = view;
                    viewPresenter.InitializeView();

                    view.Show();
                };

            return asyncOperationHandle;
        }

        public void Dispose()
        {
            SignalsUnsubscribe();
        }
    }
}