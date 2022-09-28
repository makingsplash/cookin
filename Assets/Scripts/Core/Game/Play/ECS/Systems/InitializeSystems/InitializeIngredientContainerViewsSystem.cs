using System.Collections.Generic;
using Entitas;
using Play.ECS;

namespace Core.Game.Play.ECS.Systems.InitializeSystems
{
    public class InitializeIngredientContainerViewsSystem : IInitializeSystem
    {
        private GameContext _context;
        private List<IngredientsContainerUpdatableViewBehaviour> _views;


        public InitializeIngredientContainerViewsSystem(Contexts contexts, List<IngredientsContainerUpdatableViewBehaviour> views)
        {
            _context = contexts.game;
            _views = views;
        }

        public void Initialize()
        {
            foreach (var view in _views)
            {
                var entity = _context.CreateEntity();
                entity.AddPlayECSIngredientContainerView(new Stack<IngredientTypes>(), view);
                view.Link(entity);
            }
        }
    }
}