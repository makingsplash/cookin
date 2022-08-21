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
        private UIHandler UIHandler { get; }


        public UIManager(DiContainer container, UIHandler uiHandler)
        {
            Container = container;
            UIHandler = uiHandler;
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
            Addressables.InstantiateAsync(presenter.PrefabPath, UIHandler.transform.position, Quaternion.identity, UIHandler.transform).Completed +=
                handle =>
                {
                    UIViewBase viewBase = handle.Result.GetComponent<UIViewBase>();
                    presenter.SetupView(viewBase);
                };
        }
    }
}