using System.Collections.Generic;
using Core.Consumables;
using Core.Game.Play.Configs;
using Core.Signals;
using Core.Transactions;
using Entitas;
using Zenject;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class CollectAssembledDishSystem : ReactiveSystem<GameEntity>
    {
        private LevelDishes LevelDishes { get; }
        private SignalBus SignalBus { get; }
        private LevelConfig LevelConfig { get; }

        public CollectAssembledDishSystem(GameContext context, LevelDishes levelDishes, SignalBus signalBus, LevelConfig levelconfig, LevelConfig levelConfig)
            : base(context)
        {
            LevelDishes = levelDishes;
            SignalBus = signalBus;
            LevelConfig = levelConfig;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PlayECSDishesAssembledDish);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSDishesAssembledDish;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            GameEntity container = entities[0];
            Dish assembledDish = container.playECSDishesAssembledDish.Dish;

            foreach(var (guestEntity, order) in LevelDishes.ActiveMultipleIngredientOrders)
            {
                if (order.Ingredients.Count != assembledDish.Ingredients.Count)
                {
                    continue;
                }

                bool validDish = true;
                for (int j = 0; j < order.Ingredients.Count; j++)
                {
                    if (order.Ingredients[j] != assembledDish.Ingredients[j])
                    {
                        validDish = false;

                        break;
                    }
                }

                if (validDish)
                {
                    MarkDishAsCompleted(container, assembledDish, guestEntity);
                    ApplyDishReward();
                    MakeGuestServed(guestEntity);

                    break;
                }
            }
        }

        private void MarkDishAsCompleted(GameEntity container, Dish completedDish, GameEntity guestEntity)
        {
            container.AddPlayECSDishesCollectedDish(completedDish);
            LevelDishes.CompleteMultipleIngredientsOrder(guestEntity);
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