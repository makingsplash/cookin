using System;
using Core.Managers;
using Core.UI.Elements;
using Core.UI.Elements.Popup;
using Core.UI.Popups;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Core.UI
{
    public class UIManager : MonoBehaviour
    {
         /*
          * Вьюшки сами себя дестроят
          */

         /*
          * Флоу работы со спавном:
          * - Приходит эвент с типом UIView и UIViewPresenter которую нужно заспавнить
          *      Spawner инстанциирует префаб View (путь из UIViewPresenter.PrefabPath)
          *
          *      через Zenject создаём ViewPresenter, инжектя конструктор
          *      UIViewPresenter.SetupView(), чередаём туда ссылку на View
          *      в SetupView запоминаем ссылку на View и вызываем UIView.Initialize(), в который передаём нужные параметры и зависимости (на свойства)
          */

        private void Awake()
        {
            MakeTestSettingsPopup();
        }

        private void MakeTestSettingsPopup()
        {
            SavingsManager savingsManager = new SavingsManager
            {
                IsMusicEnabled = false
            };

            SettingsPopupViewPresenter popupPresenter = new SettingsPopupViewPresenter(savingsManager);

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