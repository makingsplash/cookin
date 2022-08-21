using Core.Managers;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class GameStarter : MonoBehaviour
    {
        private UIManager UIManager { get; set; }

        [Inject]
        private void Inject(UIManager uiManager)
        {
            UIManager = uiManager;
        }

        private void Start()
        {
            UIManager.SpawnHomeHUD();
        }
    }
}