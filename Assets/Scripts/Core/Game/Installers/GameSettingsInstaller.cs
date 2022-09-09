using Core.Game.Home.Configs;
using UnityEngine;
using Zenject;

namespace Core.Game.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public BankConfig BankConfig;

        public override void InstallBindings()
        {
            Container.Bind<BankConfig>().FromInstance(BankConfig);
        }
    }
}