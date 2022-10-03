using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Game.Play.ECS;
using Play.ECS.Common;
using TMPro;
using UnityEngine;

namespace Play.ECS
{
    public class IngredientsContainerViewBehaviourBehaviour : EntityViewBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textIngredientsDisplay;

        public List<IngredientTypes> Ingredients;


        public void UpdateView()
        {
            Ingredients = Entity.playECSIngredientContainerView.Ingredients.ToList();

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