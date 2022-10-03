using Core.Game.Play.ECS;
using Play.ECS.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Play.ECS
{
    public class IngredientProducerViewBehaviour : EntityView
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
            // создавать сущность с компонентом ProducedIngredient ??
            // что за сущность тут вообще используется?


            // а, или всё ок, по идее можно ща в инспекторе добавить новый компонент на пролинкованную сущность, типо это новый ингридиент
            // он должен быть коллектнут и удалён (компонент)

            Entity.AddPlayECSIngredient(_ingredientType);
        }
    }
}