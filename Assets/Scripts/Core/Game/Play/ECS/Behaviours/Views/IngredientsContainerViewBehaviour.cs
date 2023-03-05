using System.Collections.Generic;
using System.Linq;
using Core.Game.Play.Configs;
using Core.Game.Play.ECS;
using Play.ECS.Common;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Play.ECS
{
    public class IngredientsContainerViewBehaviour : EntityViewBehaviour
    {
        [SerializeField]
        private Button _collectButton;

        [SerializeField]
        private Button _resetButton;

        [SerializeField]
        private Transform _ingrevientsViewRoot;

        private List<IngredientType> _ingredients => Entity.playECSIngredientContainerView.Ingredients;


        public override void Initialize(GameContext context)
        {
            base.Initialize(context);

            Entity.AddPlayECSIngredientContainerView(this, new List<IngredientType>());
            Entity.playECSIngredientContainerView.Ingredients
                .ObserveEveryValueChanged(x => x.Count)
                .Subscribe(x => OnIngredientsChanged())
                .AddTo(this);
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
                SpawnIngredient(_ingredients.Last());
            }
            else
            {
                foreach (Transform t in _ingrevientsViewRoot)
                {
                    Destroy(t.gameObject);
                }

                Entity.AddPlayECSClearedContainer(Entity.playECSIngredientContainerView);
            }
        }

        private void SpawnIngredient(IngredientType ingredient)
        {
            Entity.AddPlayECSSpawnIngredientViews(new List<IngredientType>{ingredient}, _ingrevientsViewRoot);
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