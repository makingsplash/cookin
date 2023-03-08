using Core.Game.Installers;
using Core.Game.Play.Configs;
using Core.Game.Play.UI;

namespace Core.Game.Play.Installers
{
    public class PlayGameSceneInstaller : GameSceneInstaller
    {
        public PlayUIRoot PlayUIRoot;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.Bind<LevelDishes>().AsSingle();
            Container.Bind<IngredientViewSpawner>().AsSingle();
            Container.Bind<PlayUIRoot>().FromInstance(PlayUIRoot).AsSingle();
        }
    }
}