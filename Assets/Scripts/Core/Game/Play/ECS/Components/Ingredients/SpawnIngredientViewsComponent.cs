using System.Collections.Generic;
using Core.Game.Play.ECS;
using Entitas;
using UnityEngine;

namespace Play.ECS
{
    [Game]
    public class SpawnIngredientViewsComponent : IComponent
    {
        public List<IngredientType> Ingredients;
        public Transform Root;
    }
}