using Entitas;

namespace Core.Game.Play.ECS.Systems.ExecuteSystems
{
    public class TimerUpdateViewSystem : IInitializeSystem, IExecuteSystem
    {
        private GameContext _gameContext;
        private IGroup<GameEntity> _timerViewComponents;


        public TimerUpdateViewSystem(GameContext context)
        {
            _gameContext = context;
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
                    entity.playECSTimerView.View.UpdateView();
                }
            }
        }
    }
}