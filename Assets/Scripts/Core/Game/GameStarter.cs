using Core.Context;
using Core.Game.Context;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class GameStarter : MonoBehaviour
    {
        private ContextManager ContextManager {get; set; }

        [Inject]
        private void Inject(ContextManager contextManager)
        {
            ContextManager = contextManager;
        }

        private void Start()
        {
            ContextManager.Load<HomeContext>().Forget();
        }
    }
}