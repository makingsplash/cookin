using Core.UI.Elements.Base;

namespace Core.Game.Home.UI.HUD
{
    public class HomeHUDView : UIViewBase
    {
        private HomeHUDViewPresenter HomeHUDViewPresenter => Presenter as HomeHUDViewPresenter;

        public void OnWidgetSettingsClick()
        {
            HomeHUDViewPresenter.ProcessSettingsWidgetClick();
        }
    }
}