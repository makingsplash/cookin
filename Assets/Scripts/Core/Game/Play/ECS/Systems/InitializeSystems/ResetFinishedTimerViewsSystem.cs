using Entitas;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.InitializeSystems
{
    public class RenameFinishedTimerViewsSystem : IInitializeSystem
    {
        private GameContext _gameContext;
        private IGroup<GameEntity> _group;

        public RenameFinishedTimerViewsSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
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
                var timerView = (TimerViewBehaviour) gameEntity.playECSTimerView.View;
                timerView.ResetView();
            }
        }
    }
}