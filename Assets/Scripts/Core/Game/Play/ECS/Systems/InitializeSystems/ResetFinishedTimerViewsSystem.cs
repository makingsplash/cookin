using Entitas;

namespace Core.Game.Play.ECS.Systems.InitializeSystems
{
    public class ResetFinishedTimerViewsSystem : IInitializeSystem
    {
        private GameContext _gameContext;
        private IGroup<GameEntity> _group;


        public ResetFinishedTimerViewsSystem(GameContext context)
        {
            _gameContext = context;
        }

        public void Initialize()
        {
            _group = _gameContext.GetGroup(GameMatcher.PlayECSTimerView);

            foreach (var entity in _group)
            {
                entity.OnComponentAdded += TryResetFinishedView;
            }
        }

        private void TryResetFinishedView(IEntity entity, int index, IComponent component)
        {
            var gameEntity = (GameEntity) entity;
            if (gameEntity.isPlayECSFinishedTimer)
            {
                var timerView = gameEntity.playECSTimerView.View;
                timerView.ResetView();
            }
        }
    }
}