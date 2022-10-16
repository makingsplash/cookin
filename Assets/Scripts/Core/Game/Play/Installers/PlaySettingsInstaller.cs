using Core.Game.Play.Configs;
using UnityEngine;
using Zenject;

namespace Core.Game.Play.Installers
{
    [CreateAssetMenu(fileName = "PlaySettingsInstaller", menuName = "Installers/PlaySettingsInstaller")]
    public class PlaySettingsInstaller : ScriptableObjectInstaller<PlaySettingsInstaller>
    {
        [SerializeField]
        private LevelDishesConfig levelDishesConfig;

        public override void InstallBindings()
        {
            Container.Bind<LevelDishesConfig>().FromInstance(levelDishesConfig);
        }
    }
}