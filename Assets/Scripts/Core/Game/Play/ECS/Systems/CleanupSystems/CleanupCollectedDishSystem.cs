using System.Collections.Generic;
using Core.Game.Play.ECS.Systems.ReactiveSystems;
using Entitas;

namespace Core.Game.Play.ECS.Systems.CleanupSystems
{
    public class CleanupCollectedDishSystem : ICleanupSystem
    {
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new ();
        private readonly StoreIngredientsIntoContainersSystem _storingSystem;

        public CleanupCollectedDishSystem(GameContext context, StoreIngredientsIntoContainersSystem storingSystem)
        {
            _context = context;
            _group = _context.GetGroup(GameMatcher.PlayECSDishesCollectedDish);
            _storingSystem = storingSystem;
        }

        public void Cleanup()
        {
            foreach (var e in _group.GetEntities(_buffer))
            {
                var container = e.playECSIngredientContainerView;

                container.Ingredients.Clear();

                _storingSystem.UpdatePossibleIngredientsForContainer(container);

                e.RemovePlayECSDishesCollectedDish();
            }
        }
    }
}