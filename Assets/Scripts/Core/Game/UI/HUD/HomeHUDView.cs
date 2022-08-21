using Core.UI.Elements;

namespace Core.Game.UI.HUD
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