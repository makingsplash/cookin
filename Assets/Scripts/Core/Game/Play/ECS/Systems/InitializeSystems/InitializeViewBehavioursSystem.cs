using System.Collections.Generic;
using Entitas;
using Play.ECS.Common;

namespace Core.Game.Play.ECS.Systems.InitializeSystems
{
    public class InitializeViewBehavioursSystem : IInitializeSystem
    {
        private GameContext _context;
        private List<EntityViewBehaviour> _views;


        public InitializeViewBehavioursSystem(GameContext context, List<EntityViewBehaviour> views)
        {
            _context = context;
            _views = views;
        }

        public void Initialize()
        {
            foreach (var view in _views)
            {
                view.Initialize(_context);
            }
        }
    }
}