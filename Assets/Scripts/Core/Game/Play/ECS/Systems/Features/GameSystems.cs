using System.Collections.Generic;
using Core.Game.Play.ECS.Systems.CleanupSystems;
using Core.Game.Play.ECS.Systems.ExecuteSystems;
using Core.Game.Play.ECS.Systems.InitializeSystems;
using Core.Game.Play.ECS.Systems.ReactiveSystems;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.Features
{
    public class GameSystems : Feature
    {
        public GameSystems(
            Contexts contexts,
            List<IngredientProducerViewBehaviourBehaviour> ingredientProducerViews,
            List<IngredientsContainerViewBehaviourBehaviour> ingredientsContainerViews,
            List<TimerViewBehaviourBehaviour> timerViews)
        {
            Add(new InitializeIngredientProducerViewsSystem(contexts, ingredientProducerViews));
            Add(new InitializeIngredientContainerViewsSystem(contexts, ingredientsContainerViews));
            Add(new InitializeTimerViewsSystem(contexts, timerViews));
            Add(new RenameFinishedTimerViewsSystem(contexts));

            Add(new TimerTickSystem(contexts));
            Add(new TimerViewUpdateSystem(contexts));

            Add(new StoreIngredientsIntoContainersSystem(contexts.game));
            Add(new UpdateIngredientContainerViewSystem(contexts.game));

            Add(new CleanupProducedIngredientsSystem(contexts));
            Add(new CleanupFinishedTimersSystem(contexts));
        }
    }
}