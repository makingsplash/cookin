using Core.Game.UI.HUD;
using Core.UI.Elements;
using Core.UI.Popups;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Core.Managers
{
    public class UIManager
    {
        private DiContainer Container { get; }
        private UIRoot UIRoot { get; }


        public UIManager(DiContainer container, UIRoot uiRoot)
        {
            Container = container;
            UIRoot = uiRoot;
        }

        public void SpawnHomeHUD()
        {
            var popupPresenter = Container.Instantiate<HomeHUDViewPresenter>();

            CreateUIView(popupPresenter);
        }

        public void SpawnSettingsPopup()
        {
            var popupPresenter = Container.Instantiate<SettingsPopupViewPresenter>();

            CreateUIView(popupPresenter);
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
    }
}