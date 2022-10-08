using System.Collections.Generic;
using Entitas;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.InitializeSystems
{
    public class InitializeTimerViewsSystem : IInitializeSystem
    {
        private GameContext _context;
        private List<TimerViewBehaviour> _views;


        public InitializeTimerViewsSystem(GameContext context, List<TimerViewBehaviour> views)
        {
            _context = context;
            _views = views;
        }

        public void Initialize()
        {
            foreach (var view in _views)
            {
                var entity = _context.CreateEntity();

                view.Link(entity);
                entity.AddPlayECSTimerView(view);
            }
        }
    }
}