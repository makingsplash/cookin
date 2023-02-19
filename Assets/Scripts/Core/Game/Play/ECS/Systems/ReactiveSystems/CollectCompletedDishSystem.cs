using System.Collections.Generic;
using Core.Consumables;
using Core.Game.Play.Configs;
using Core.Signals;
using Core.Transactions;
using Entitas;
using Play.ECS;
using UnityEngine;
using Zenject;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class CollectCompletedDishSystem : ReactiveSystem<GameEntity>
    {
        private readonly LevelDishes _levelDishes;
        private SignalBus SignalBus { get; }

        public CollectCompletedDishSystem(GameContext context, LevelDishes levelDishes, SignalBus signalBus) : base(context)
        {
            _levelDishes = levelDishes;
            SignalBus = signalBus;
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

            foreach(var (guest, order) in _levelDishes.ActiveOrders)
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
                    container.AddPlayECSDishesCollectedDish(completedDish);
                    _levelDishes.CompleteOrder(guest);

                    Transaction earnedStars = new Transaction(ConsumableType.Star, 6);
                    SignalBus.TryFire(new TransactionSignal(earnedStars));

                    GuestViewBehaviour guestView = guest.playECSGuestView.View;
                    guestView.SetState(GuestState.WalkOut);

                    Vector3 startPos = guestView.gameObject.transform.localPosition;
                    Vector3 endPos = new Vector3(-2000, -312, 0);
                    int direction = -1;
                    float speed = 300f;
                    float walkingTime = Mathf.Abs((endPos - startPos).x) / speed;

                    guest.AddPlayECSWalkingGuest(guestView, direction, speed, walkingTime);

                    break;
                }
            }
        }
    }
}