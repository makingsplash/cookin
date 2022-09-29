using Core.Game.Play.ECS;
using Entitas;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Play.ECS
{
    public class IngredientProducerViewBehaviour : MonoBehaviour
    {
        [SerializeField]
        private IngredientTypes _ingredientType;

        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _textIngredientDisplay;


        private GameEntity _gameEntity;


        public void Link(IEntity entity)
        {
            _gameEntity = (GameEntity) entity;
        }

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);

            _textIngredientDisplay.text = _ingredientType.ToString();
        }

        private void OnClick()
        {
            _gameEntity.AddPlayECSIngredient(_ingredientType);
        }
    }
}