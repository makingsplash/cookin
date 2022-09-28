using Entitas;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.Play.ECS.Behaviours
{
    public class IngredientProducerViewBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _textMeshProUGUI;

        [SerializeField]
        private IngredientTypes _ingredientType;

        private GameEntity _gameEntity;


        public void Link(IEntity entity)
        {
            _gameEntity = (GameEntity) entity;
        }

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);

            _textMeshProUGUI.text = _ingredientType.ToString();
        }

        private void OnClick()
        {
            _gameEntity.AddCoreGamePlayECSComponentsIngredient(_ingredientType);
        }
    }
}