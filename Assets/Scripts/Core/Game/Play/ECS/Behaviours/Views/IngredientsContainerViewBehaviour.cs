using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Game.Play.Configs;
using Core.Game.Play.ECS;
using Play.ECS.Common;
using TMPro;
using UniRx;
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

        [SerializeField]
        private Button _resetButton;

        private List<IngredientType> _ingredients => Entity.playECSIngredientContainerView.Ingredients;


        public override void Initialize(GameContext context)
        {
            base.Initialize(context);

            Entity.AddPlayECSIngredientContainerView(this, new List<IngredientType>());
            Entity.playECSIngredientContainerView.Ingredients
                .ObserveEveryValueChanged(x => x.Count).Subscribe(x => OnIngredientsChanged());
        }

        private void Awake()
        {
            _collectButton.onClick.AddListener(OnCollect);
            _resetButton.onClick.AddListener(OnReset);
        }

        private void OnIngredientsChanged()
        {
            if (_ingredients.Any())
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (var ingredient in _ingredients)
                {
                    stringBuilder.Append(ingredient.ToString());
                    stringBuilder.Append("\n");
                }

                _textIngredientsDisplay.text = stringBuilder.ToString();
            }
            else
            {
                _textIngredientsDisplay.text = string.Empty;

                Entity.AddPlayECSClearedContainer(Entity.playECSIngredientContainerView);
            }
        }

        private void OnReset()
        {
            _ingredients.Clear();
        }

        private void OnCollect()
        {
            if (_ingredients.Any())
            {
                Entity.AddPlayECSDishesAssembledDish(new Dish{Ingredients = _ingredients});
            }
        }
    }
}