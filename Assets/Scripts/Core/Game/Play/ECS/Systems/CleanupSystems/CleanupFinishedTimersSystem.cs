using Entitas;

namespace Core.Game.Play.ECS.Systems.CleanupSystems
{
    public class CleanupFinishedTimersSystem : ICleanupSystem
    {
        private GameContext _gameContext;


        public CleanupFinishedTimersSystem(GameContext context)
        {
            _gameContext = context;
        }

        public void Cleanup()
        {
            var group = _gameContext.GetGroup(GameMatcher.PlayECSFinishedTimer).GetEntities();

            foreach (var entity in group)
            {
                entity.isPlayECSFinishedTimer = false;
            }
        }
    }
}