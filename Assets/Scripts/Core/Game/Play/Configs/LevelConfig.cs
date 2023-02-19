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
        public AssetReference GuestViewPrefab;
        public int GuestsSpawnAmount;
        public float GuestsSpawnRate;
        public float GuestsSpeed;
        public float HorizontalStartingPointLeft;
        public float HorizontalStartingPointRight;
        public float GuestHorizontalOrderPosition;
    }

    [Serializable]
    public class Dish
    {
        public List<IngredientType> Ingredients;
    }
}