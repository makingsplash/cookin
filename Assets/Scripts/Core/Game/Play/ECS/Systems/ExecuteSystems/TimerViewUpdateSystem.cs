using Entitas;

namespace Core.Game.Play.ECS.Systems.ExecuteSystems
{
    public class TimerViewUpdateSystem : IInitializeSystem, IExecuteSystem
    {
        private GameContext _gameContext;
        private IGroup<GameEntity> _timerViewComponents;

        public TimerViewUpdateSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Initialize()
        {
            _timerViewComponents = _gameContext.GetGroup(GameMatcher.PlayECSTimerView);
        }

        public void Execute()
        {
            foreach (var entity in _timerViewComponents)
            {
                if (entity.hasPlayECSRunningTimer)
                {
                    entity.playECSTimerView.UpdatableView.UpdateView();
                }
            }
        }
    }
}