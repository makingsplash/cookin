using System.Collections.Generic;
using Core.Game.Play.ECS.Systems.ReactiveSystems;
using Entitas;

namespace Core.Game.Play.ECS.Systems.CleanupSystems
{
    public class CleanupClearedContainersSystem : ICleanupSystem
    {
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new ();
        private readonly StoreIngredientsIntoContainersSystem _storingSystem;

        public CleanupClearedContainersSystem(GameContext context, StoreIngredientsIntoContainersSystem storingSystem)
        {
            _context = context;
            _group = _context.GetGroup(GameMatcher.PlayECSClearedContainer);
            _storingSystem = storingSystem;
        }

        public void Cleanup()
        {
            foreach (var e in _group.GetEntities(_buffer))
            {
                var container = e.playECSIngredientContainerView;

                _storingSystem.UpdatePossibleIngredientsForContainer(container);

                e.RemovePlayECSClearedContainer();
            }
        }
    }
}