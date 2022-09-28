using System.Collections.Generic;
using Entitas;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.ExecuteSystems
{
    public class TimerViewUpdateSystem : IExecuteSystem
    {
        private GameContext _gameContext;
        private List<TimerUpdatableViewBehaviour> _views;

        public TimerViewUpdateSystem(Contexts contexts, List<TimerUpdatableViewBehaviour> views)
        {
            _gameContext = contexts.game;
            _views = views;
        }

        public void Execute()
        {
            foreach (var view in _views)
            {
                view.UpdateView();
            }
        }
    }
}