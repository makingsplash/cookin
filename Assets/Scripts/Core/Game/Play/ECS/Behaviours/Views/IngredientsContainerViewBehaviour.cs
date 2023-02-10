using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Game.Play.ECS;
using Play.ECS.Common;
using TMPro;
using UnityEngine;

namespace Play.ECS
{
    public class IngredientsContainerViewBehaviour : EntityViewBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textIngredientsDisplay;

        public List<IngredientType> Ingredients;


        public override void Initialize(GameContext context)
        {
            base.Initialize(context);
            Entity.AddPlayECSIngredientContainerView(this, new List<IngredientType>());
        }

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