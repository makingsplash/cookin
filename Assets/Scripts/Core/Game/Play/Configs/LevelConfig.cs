using System;
using System.Collections.Generic;
using Core.Game.Play.ECS;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Game.Play.Configs
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = "LevelConfigs/" + nameof(LevelConfig))]
    public class LevelConfig : ScriptableObject
    {
        public List<Dish> Dishes;
        public int GuestsSpawnAmount;
        public float GuestsSpawnRate;
        public AssetReference GuestViewPrefab;
    }

    [Serializable]
    public class Dish
    {
        public List<IngredientType> Ingredients;
    }
}