using System.Collections.Generic;
using Entitas;

namespace Core.Game.Play.ECS.Systems.CleanupSystems
{
    public class CleanupProducedIngredientsSystem : ICleanupSystem
    {
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _group;
        readonly List<GameEntity> _buffer = new ();

        public CleanupProducedIngredientsSystem(Contexts contexts)
        {
            _context = contexts.game;
            _group = _context.GetGroup(GameMatcher.CoreGamePlayECSComponentsIngredient);
        }

        public void Cleanup()
        {
            foreach (var e in _group.GetEntities(_buffer))
            {
                e.RemoveCoreGamePlayECSComponentsIngredient();
            }
        }
    }
}