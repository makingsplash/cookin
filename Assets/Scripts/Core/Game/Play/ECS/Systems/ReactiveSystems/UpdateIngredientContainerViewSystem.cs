using System.Collections.Generic;
using Entitas;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class UpdateIngredientContainerViewSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        private GameContext _context;

        private GameEntity[] viewsGroup;

        public UpdateIngredientContainerViewSystem(IContext<GameEntity> context) : base(context)
        {
            _context = (GameContext) context;
        }

        public void Initialize()
        {
            viewsGroup = _context.GetGroup(GameMatcher.CoreGamePlayECSComponentsIngredientContainerView).GetEntities();
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CoreGamePlayECSComponentsIngredient);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCoreGamePlayECSComponentsIngredient;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in viewsGroup)
            {
                e.coreGamePlayECSComponentsIngredientContainerView.ViewBehaviour.UpdateView();
            }
        }
    }
}