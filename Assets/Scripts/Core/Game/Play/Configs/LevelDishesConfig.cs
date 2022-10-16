using System;
using System.Collections.Generic;
using Core.Game.Play.ECS;
using UnityEngine;

namespace Core.Game.Play.Configs
{
    [CreateAssetMenu(fileName = nameof(LevelDishesConfig), menuName = "LevelConfigs/" + nameof(LevelDishesConfig))]
    public class LevelDishesConfig : ScriptableObject
    {
        public List<Dish> Dishes;
    }

    [Serializable]
    public class Dish
    {
        public List<IngredientTypes> Ingredients;
    }
}