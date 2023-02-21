using System.Collections.Generic;
using Core.Consumables;
using Core.Game.Play.Configs;
using Core.Signals;
using Core.Transactions;
using Entitas;
using Zenject;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class CollectCompletedDishSystem : ReactiveSystem<GameEntity>
    {
        private LevelDishes LevelDishes { get; }
        private SignalBus SignalBus { get; }
        private LevelConfig LevelConfig { get; }

        public CollectCompletedDishSystem(GameContext context, LevelDishes levelDishes, SignalBus signalBus, LevelConfig levelconfig, LevelConfig levelConfig)
            : base(context)
        {
            LevelDishes = levelDishes;
            SignalBus = signalBus;
            LevelConfig = levelConfig;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PlayECSDishesCompletedDish);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSDishesCompletedDish;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity container = entities[0];
            Dish completedDish = container.playECSDishesCompletedDish.Dish;

            foreach(var (guestEntity, order) in LevelDishes.ActiveOrders)
            {
                if (order.Ingredients.Count != completedDish.Ingredients.Count)
                {
                    continue;
                }

                bool validDish = true;
                for (int j = 0; j < order.Ingredients.Count; j++)
                {
                    if (order.Ingredients[j] != completedDish.Ingredients[j])
                    {
                        validDish = false;

                        break;
                    }
                }

                if (validDish)
                {
                    MarkDishAsCompleted(container, completedDish, guestEntity);
                    ApplyDishReward();
                    MakeGuestServed(guestEntity);

                    break;
                }
            }
        }

        private void MarkDishAsCompleted(GameEntity container, Dish completedDish, GameEntity guestEntity)
        {
            container.AddPlayECSDishesCollectedDish(completedDish);
            LevelDishes.CompleteOrder(guestEntity);
        }

        private void ApplyDishReward()
        {
            Transaction earnedStars = new Transaction(ConsumableType.Star, 6);
            SignalBus.TryFire(new TransactionSignal(earnedStars));
        }

        private void MakeGuestServed(GameEntity guestEntity)
        {
            guestEntity.RemovePlayECSUnservedGuest();
            guestEntity.AddPlayECSServedGuest(guestEntity);
        }
    }
}