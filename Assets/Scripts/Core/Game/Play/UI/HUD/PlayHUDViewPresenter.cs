using Core.Game.Context;
using Core.Game.Home;
using Core.UI.Elements.Base;
using Cysharp.Threading.Tasks;

namespace Core.Game.Play.UI.HUD
{
    public class PlayHUDViewPresenter : ViewPresenterBase
    {
        private PlayHUDView PlayHUDView => (PlayHUDView) View;

        private ContextManager ContextManager { get; }


        public PlayHUDViewPresenter(ContextManager contextManager)
            : base("Assets/GameAssets/Play/Prefabs/PlayHUD.prefab")
        {
            ContextManager = contextManager;
        }

        public override void InitializeView()
        {
            base.InitializeView();
        }

        protected override void BindView()
        {
            PlayHUDView.HomeButton.onClick.AddListener(EnterHomeContext);
        }

        private void EnterHomeContext()
        {
            ContextManager.Load<HomeContext>().Forget();
        }
    }
}