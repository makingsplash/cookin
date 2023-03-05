using Core.Game.Installers;
using Core.Game.Play.Configs;
using Core.Game.Play.UI;

namespace Core.Game.Play.Installers
{
    public class PlayGameSceneInstaller : GameSceneInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.Bind<LevelDishes>().AsSingle();
            Container.Bind<IngredientViewSpawner>().AsSingle();
        }
    }
}