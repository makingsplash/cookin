using System;
using System.Collections.Generic;
using Core.Game.Play.ECS;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

namespace Core.Game.Play.Configs
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = "LevelConfigs/" + nameof(LevelConfig))]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField]
        private float _guestsSpawnRateFrom;
        [SerializeField]
        private float _guestsSpawnRateTo;

        public float GuestsSpawnRate => Random.Range(_guestsSpawnRateFrom, _guestsSpawnRateTo);

        public AssetReference GuestViewPrefab;

        public List<IngredientView> IngredientViews;
        public List<Dish> Dishes;
    }

    [Serializable]
    public class Dish
    {
        public List<IngredientType> Ingredients;
    }

    [Serializable]
    public class IngredientView
    {
        public IngredientType Type;
        public AssetReference Prefab;
    }
}