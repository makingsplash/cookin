using System.Collections.Generic;
using System.Linq;
using Core.Consumables;
using Core.Game.Play.Configs;
using Core.Signals;
using Core.Transactions;
using Entitas;
using Zenject;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class CollectSingleIngredientDishSystem : ReactiveSystem<GameEntity>
    {
        private LevelDishes LevelDishes { get; }
        private SignalBus SignalBus { get; }
        private LevelConfig LevelConfig { get; }

        public CollectSingleIngredientDishSystem(GameContext context, LevelDishes levelDishes, SignalBus signalBus, LevelConfig levelconfig, LevelConfig levelConfig)
            : base(context)
        {
            LevelDishes = levelDishes;
            SignalBus = signalBus;
            LevelConfig = levelConfig;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PlayECSIngredient);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSIngredient && LevelDishes.ActiveSingleIngredientOrders.Any();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity producerEntity = entities[0];
            IngredientType ingredient = producerEntity.playECSIngredient.IngredientType;

            foreach (var (guestEntity, order) in LevelDishes.ActiveSingleIngredientOrders)
            {
                if (order.Ingredients[0] == ingredient)
                {
                    producerEntity.AddPlayECSCollectedIngredient(ingredient);

                    MarkDishAsCompleted(guestEntity);
                    ApplyDishReward();
                    MakeGuestServed(guestEntity);

                    break;
                }
            }
        }

        private void MarkDishAsCompleted(GameEntity guestEntity)
        {
            LevelDishes.CompleteSingleIngredientsOrder(guestEntity);
        }

        private void ApplyDishReward()
        {
            Transaction earnedStars = new Transaction(ConsumableType.Star, 6);
            SignalBus.TryFire(new TransactionSignal(earnedStars));
        }

        private void MakeGuestServed(GameEntity guestEntity)
        {
            guestEntity.RemovePlayECSGuestOrder();
            guestEntity.AddPlayECSServedGuest(guestEntity);
        }
    }
}