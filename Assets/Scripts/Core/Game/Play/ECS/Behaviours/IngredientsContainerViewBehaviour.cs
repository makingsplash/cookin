using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using TMPro;
using UnityEngine;

namespace Core.Game.Play.ECS.Behaviours
{
    public class IngredientsContainerViewBehaviour : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _textMeshProUGUI;

        public List<IngredientTypes> Ingredients;

        private GameEntity _gameEntity;

        public void Link(IEntity entity)
        {
            _gameEntity = (GameEntity) entity;
        }

        public void UpdateView()
        {
            Ingredients = _gameEntity.coreGamePlayECSComponentsIngredientContainerView.Ingredients.ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var ingredient in Ingredients)
            {
                stringBuilder.Append(ingredient.ToString());
                stringBuilder.Append("\n");
            }

            _textMeshProUGUI.text = stringBuilder.ToString();
        }
    }
}