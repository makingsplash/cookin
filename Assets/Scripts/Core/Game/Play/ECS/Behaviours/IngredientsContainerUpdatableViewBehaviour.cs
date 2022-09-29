using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Game.Play.ECS;
using Entitas;
using TMPro;
using UnityEngine;

namespace Play.ECS
{
    public class IngredientsContainerUpdatableViewBehaviour : UpdatableViewBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textIngredientsDisplay;

        public List<IngredientTypes> Ingredients;


        public override void UpdateView()
        {
            Ingredients = _gameEntity.playECSIngredientContainerView.Ingredients.ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var ingredient in Ingredients)
            {
                stringBuilder.Append(ingredient.ToString());
                stringBuilder.Append("\n");
            }

            _textIngredientsDisplay.text = stringBuilder.ToString();
        }
    }
}