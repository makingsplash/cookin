using System.Collections.Generic;
using Entitas;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.InitializeSystems
{
    public class InitializeTimerViewsSystem : IInitializeSystem
    {
        private GameContext _context;
        private List<TimerUpdatableViewBehaviour> _views;

        public InitializeTimerViewsSystem(Contexts contexts, List<TimerUpdatableViewBehaviour> views)
        {
            _context = contexts.game;
            _views = views;
        }

        public void Initialize()
        {
            foreach (var view in _views)
            {
                var entity = _context.CreateEntity();
                entity.AddPlayECSTimerView(10.0f, 0.0f, true, view);
                view.Link(entity);
            }
        }
    }
}