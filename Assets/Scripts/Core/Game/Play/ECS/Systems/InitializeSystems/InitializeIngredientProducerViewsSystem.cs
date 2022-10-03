using System.Collections.Generic;
using Entitas;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.InitializeSystems
{
    public class InitializeIngredientProducerViewsSystem : IInitializeSystem
    {
        private GameContext _context;
        private List<IngredientProducerViewBehaviourBehaviour> _views;


        public InitializeIngredientProducerViewsSystem(Contexts contexts, List<IngredientProducerViewBehaviourBehaviour> views)
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
                entity.AddPlayECSIngredientProducerView(view);
            }
        }
    }
}