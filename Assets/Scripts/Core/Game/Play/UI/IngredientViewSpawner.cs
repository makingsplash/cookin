using Core.Game.Play.Configs;
using Core.Game.Play.ECS;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Game.Play.UI
{
    public class IngredientViewSpawner
    {
        private LevelConfig _levelConfig;

        public IngredientViewSpawner(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
        }

        public async UniTask SpawnIngredient(IngredientType type, Transform root)
        {
            IngredientView ingredientView = _levelConfig.IngredientViews.Find(view => view.Type == type);

            await ingredientView.Prefab.InstantiateAsync(root);
        }
    }
}