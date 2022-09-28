using System.Collections.Generic;
using Core.Game.Play.ECS.Behaviours;
using Entitas;

namespace Core.Game.Play.ECS.Systems.InitializeSystems
{
    public class InitializeIngredientProducerViewsSystem : IInitializeSystem
    {
        private GameContext _context;
        private List<IngredientProducerViewBehaviour> _views;


        public InitializeIngredientProducerViewsSystem(Contexts contexts, List<IngredientProducerViewBehaviour> views)
        {
            _context = contexts.game;
            _views = views;
        }

        public void Initialize()
        {
            foreach (var view in _views)
            {
                var entity = _context.CreateEntity();
                view.Link(entity);
            }
        }
    }
}