using System.Collections.Generic;
using Core.Game.Play.Configs;
using Entitas;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class MakeGuestMovingSystem : ReactiveSystem<GameEntity>
    {
        private LevelConfig LevelConfig { get; }


        // inject guest seats
        public MakeGuestMovingSystem(GameContext context, LevelConfig levelConfig) : base(context)
        {
            LevelConfig = levelConfig;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnyOf(
                GameMatcher.PlayECSUnservedGuest, GameMatcher.PlayECSServedGuest));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSUnservedGuest || entity.hasPlayECSServedGuest;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var guestView = e.playECSGuestView.View;

                if (e.hasPlayECSUnservedGuest)
                {
                    e.AddPlayECSStartHorizontalMovement(
                        100, () =>
                        {
                            e.AddPlayECSArrivedGuest(guestView);
                        });
                }
                else
                {
                    e.AddPlayECSStartHorizontalMovement(
                        LevelConfig.HorizontalStartingPointLeft, () =>
                        {
                            e.Destroy();
                        });
                }
            }
        }
    }
}