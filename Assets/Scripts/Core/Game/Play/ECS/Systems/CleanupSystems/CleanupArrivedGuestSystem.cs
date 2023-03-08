using System.Collections.Generic;
using Entitas;

namespace Core.Game.Play.ECS.Systems.CleanupSystems
{
    public class CleanupArrivedGuestSystem : ICleanupSystem
    {
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _group;
        readonly List<GameEntity> _buffer = new ();

        public CleanupArrivedGuestSystem(GameContext context)
        {
            _context = context;
            _group = _context.GetGroup(GameMatcher.PlayECSArrivedGuest);
        }

        public void Cleanup()
        {
            foreach (var e in _group.GetEntities(_buffer))
            {
                e.RemovePlayECSArrivedGuest();
            }
        }
    }
}