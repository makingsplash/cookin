using Core.Managers;
using Core.UI.Elements;

namespace Core.Game.UI.HUD
{
    public class HomeHUDViewPresenter : UIViewBasePresenter
    {
        private UIManager UIManager { get; set; }


        public HomeHUDViewPresenter(UIManager uiManager) : base("Assets/Prefabs/Game/HomeHUD.prefab")
        {
            UIManager = uiManager;
        }

        public void ProcessSettingsWidgetClick()
        {
            UIManager.SpawnSettingsPopup();
        }
    }
}