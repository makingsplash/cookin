using System.Collections.Generic;
using Entitas;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.InitializeSystems
{
    public class InitializeIngredientProducerViewsSystem : IInitializeSystem
    {
        private GameContext _context;
        private List<IngredientProducerViewBehaviour> _views;


        public InitializeIngredientProducerViewsSystem(GameContext context, List<IngredientProducerViewBehaviour> views)
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
                entity.AddPlayECSIngredientProducerView(view);
            }
        }
    }
}