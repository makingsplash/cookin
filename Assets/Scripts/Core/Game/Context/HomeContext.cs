using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Game.Context
{
    public class HomeContext : Context
    {
        public override string Scene => "Assets/Scenes/HomeScene.unity";

        public override UniTask Setup()
        {
            Debug.Log($"[{nameof(HomeContext)}]: Setup");
            return base.Setup();
        }
    }
}