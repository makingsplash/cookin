using System.Collections.Generic;
using Core.Game.Play.Configs;
using Core.Game.Play.UI;
using Cysharp.Threading.Tasks;
using Entitas;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class SpawnIngredientViewSystem : ReactiveSystem<GameEntity>
    {
        private LevelConfig LevelConfig { get; }
        private IngredientViewSpawner Spawner { get; }


        public SpawnIngredientViewSystem(GameContext context, LevelConfig levelConfig, IngredientViewSpawner spawner) : base(context)
        {
            LevelConfig = levelConfig;
            Spawner = spawner;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PlayECSSpawnIngredientViews);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSSpawnIngredientViews;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var component = e.playECSSpawnIngredientViews;
                SpawnIngredients(component).Forget();
            }
        }

        private async UniTask SpawnIngredients(SpawnIngredientViewsComponent component)
        {
            foreach (var ingredient in component.Ingredients)
            {
                await Spawner.SpawnIngredient(ingredient, component.Root);
            }
        }
    }
}