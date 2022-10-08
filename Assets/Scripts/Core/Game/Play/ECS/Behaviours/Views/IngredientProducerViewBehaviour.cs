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
        private IngredientTypes _ingredientType;

        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _textIngredientDisplay;


        private void Awake()
        {
            _button.onClick.AddListener(OnClick);

            _textIngredientDisplay.text = _ingredientType.ToString();
        }

        private void OnClick()
        {
            Entity.AddPlayECSIngredient(_ingredientType);
        }
    }
}