using UnityEngine;

namespace Core.Game.Context
{
    public class HomeContext : Context
    {
        public override string Scene => "Assets/Scenes/HomeScene.unity";

        public override void Load()
        {
            Debug.Log($"[{nameof(HomeContext)}]: Load");
            base.Load();
        }
    }
}