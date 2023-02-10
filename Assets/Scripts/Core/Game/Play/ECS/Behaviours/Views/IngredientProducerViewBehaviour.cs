using Core.Game.Play.ECS;
using Play.ECS.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Play.ECS
{
    public class IngredientProducerViewBehaviour : EntityViewBehaviour
    {
        [SerializeField]
        private IngredientType ingredientType;

        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _textIngredientDisplay;


        public override void Initialize(GameContext context)
        {
            base.Initialize(context);
            Entity.AddPlayECSIngredientProducerView(this);
        }

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);

            _textIngredientDisplay.text = ingredientType.ToString();
        }

        private void OnClick()
        {
            Entity.AddPlayECSIngredient(ingredientType);
        }
    }
}