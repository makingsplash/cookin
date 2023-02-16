using System.Text;
using Core.Game.Context;
using Core.Game.Home.Installers;
using Core.Game.Play.Configs;
using Core.Signals;
using Core.UI.Elements.Base;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Core.Game.Play.UI.HUD
{
    public class PlayHUDViewPresenter : ViewPresenterBase, ISignalListener
    {
        private PlayHUDView PlayHUDView => (PlayHUDView) View;

        private ContextManager ContextManager { get; }
        private SignalBus SignalBus { get; }
        private LevelDishes LevelDishes { get; }


        public PlayHUDViewPresenter(ContextManager contextManager, SignalBus signalBus, LevelDishes levelDishes)
            : base("Assets/GameAssets/Play/Prefabs/PlayHUD.prefab")
        {
            ContextManager = contextManager;
            SignalBus = signalBus;
            LevelDishes = levelDishes;
        }

        public override void InitializeView()
        {
            base.InitializeView();

            UpdateLevelDishesList();
        }

        protected override void BindView()
        {
            PlayHUDView.HomeButton.onClick.AddListener(EnterHomeContext);

            SignalsSubscribe();
            View.OnClose += SignalsUnsubscribe;

            base.BindView();
        }

        private void EnterHomeContext()
        {
            ContextManager.Load<HomeContext>().Forget();
        }

        public void SignalsSubscribe()
        {
            SignalBus.Subscribe<LevelDishesUpdatedSignal>(UpdateLevelDishesList);
        }

        public void SignalsUnsubscribe()
        {
            SignalBus.Unsubscribe<LevelDishesUpdatedSignal>(UpdateLevelDishesList);
        }

        private void UpdateLevelDishesList()
        {
            StringBuilder dishesList = new StringBuilder();

            foreach (var dish in LevelDishes.LevelDishesToCollect)
            {
                dishesList.Append(string.Join(", ", dish.Ingredients));
                dishesList.Append("\n");
            }

            PlayHUDView.DishesList.text = dishesList.ToString();
        }
    }
}