using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Game.Play.Configs;
using Core.Game.Play.ECS;
using Play.ECS.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Play.ECS
{
    public class IngredientsContainerViewBehaviour : EntityViewBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textIngredientsDisplay;

        [SerializeField]
        private Button _collectButton;

        public List<IngredientType> Ingredients;


        public override void Initialize(GameContext context)
        {
            base.Initialize(context);
            Entity.AddPlayECSIngredientContainerView(this, new List<IngredientType>());
        }

        private void Awake()
        {
            _collectButton.onClick.AddListener(OnCollect);
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

        public void Reset()
        {
            _textIngredientsDisplay.text = string.Empty;
        }

        private void OnCollect()
        {
            if (Ingredients.Any())
            {
                Entity.AddPlayECSDishesCompletedDish(new Dish{Ingredients = Ingredients});
            }
        }
    }
}