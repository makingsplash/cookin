using System.Collections.Generic;
using Entitas;

namespace Core.Game.Play.ECS.Systems.CleanupSystems
{
    public class CleanupCompletedDishSystem : ICleanupSystem
    {
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _group;
        readonly List<GameEntity> _buffer = new ();

        public CleanupCompletedDishSystem(GameContext context)
        {
            _context = context;
            _group = _context.GetGroup(GameMatcher.PlayECSDishesCompletedDish);
        }

        public void Cleanup()
        {
            foreach (var e in _group.GetEntities(_buffer))
            {
                e.RemovePlayECSDishesCompletedDish();
            }
        }
    }
}