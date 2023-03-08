using System.Collections.Generic;
using System.Linq;
using Core.Game.Play.Configs;
using Entitas;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class AssignOrderToGuestSystem : ReactiveSystem<GameEntity>
    {
        private LevelDishes _levelDishes;

        public AssignOrderToGuestSystem(GameContext context, LevelDishes levelDishes) : base(context)
        {
            _levelDishes = levelDishes;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PlayECSGuestOrder);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSGuestOrder;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var unServedComponent = e.playECSGuestOrder;

                Dish dish = _levelDishes.DishesToAssign.First();
                unServedComponent.Order = dish;

                _levelDishes.DishesToAssign.Remove(dish);
            }
        }
    }
}