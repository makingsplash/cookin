using System.Collections.Generic;
using System.Linq;
using Core.Game.Play.Configs;
using Core.Game.Play.UI;
using Entitas;
using Play.ECS;
using UnityEngine;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class GuestSeatingSystem : ReactiveSystem<GameEntity>
    {
        private LevelConfig LevelConfig { get; }
        private PlayUIRoot PlayUIRoot { get; }


        public GuestSeatingSystem(GameContext context, LevelConfig levelConfig, PlayUIRoot playUIRoot) : base(context)
        {
            LevelConfig = levelConfig;
            PlayUIRoot = playUIRoot;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnyOf(
                GameMatcher.PlayECSGuestOrder, GameMatcher.PlayECSServedGuest));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSGuestOrder || entity.hasPlayECSServedGuest;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                GuestViewComponent guestViewComponent = e.playECSGuestView;

                if (e.hasPlayECSGuestOrder)
                {
                    AssignSeat(guestViewComponent);

                    e.AddPlayECSStartHorizontalMovement(
                        guestViewComponent.Seat.Position.x, () =>
                        {
                            e.AddPlayECSArrivedGuest(guestViewComponent.View);
                        });
                }
                else
                {
                    UnassignSeat(guestViewComponent);

                    e.AddPlayECSStartHorizontalMovement(
                        PlayUIRoot.GuestSpawnPoint.x, () =>
                        {
                            e.Destroy();
                        });
                }
            }
        }

        private void AssignSeat(GuestViewComponent guestViewComponent)
        {
            List<GuestSeat> availableSeats = PlayUIRoot.GuestsSeats.Where(seat => seat.Available).ToList();
            int seatIndex = Random.Range(0, availableSeats.Count - 1);

            GuestSeat guestSeat = availableSeats[seatIndex];
            guestViewComponent.Seat = guestSeat;
            guestSeat.Available = false;
        }

        private void UnassignSeat(GuestViewComponent guestViewComponent)
        {
            guestViewComponent.Seat.Available = true;
            guestViewComponent.Seat = null;
        }
    }
}