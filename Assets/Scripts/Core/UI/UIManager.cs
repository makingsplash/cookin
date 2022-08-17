using Core.UI.Elements;
using Core.UI.Elements.Popup;
using Core.UI.Popups;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Core.UI
{
    public class UIManager : MonoBehaviour
    {
        private DiContainer Container { get; set; }

         [Inject]
         private void Initialize(DiContainer container)
         {
             Container = container;
         }

        private void Start()
        {
            MakeTestSettingsPopup();
        }

        private void MakeTestSettingsPopup()
        {
            SettingsPopupViewPresenter popupPresenter = Container.Instantiate<SettingsPopupViewPresenter>();

            CreateUIView(popupPresenter);
        }

        private void CreateUIView(UIViewBasePresenter presenter)
        {
            Addressables.InstantiateAsync(presenter.PrefabPath, transform.position, Quaternion.identity, transform).Completed +=
                handle =>
                {
                    PopupView popupView = handle.Result.GetComponent<PopupView>();
                    presenter.SetupView(popupView);
                };
        }
    }
}