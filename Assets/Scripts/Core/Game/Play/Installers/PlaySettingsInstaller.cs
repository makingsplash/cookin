using Core.Game.Play.Configs;
using UnityEngine;
using Zenject;

namespace Core.Game.Play.Installers
{
    [CreateAssetMenu(fileName = "PlaySettingsInstaller", menuName = "Installers/PlaySettingsInstaller")]
    public class PlaySettingsInstaller : ScriptableObjectInstaller<PlaySettingsInstaller>
    {
        [SerializeField]
        private LevelConfig levelConfig;

        public override void InstallBindings()
        {
            Container.Bind<LevelConfig>().FromInstance(levelConfig);
        }
    }
}