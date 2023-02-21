using System.Collections.Generic;
using Entitas;
using Play.ECS;
using UnityEngine;

namespace Core.Game.Play.ECS.Systems.ReactiveSystems
{
    public class ApplyHorizontalMovementSystem : ReactiveSystem<GameEntity>
    {
        public ApplyHorizontalMovementSystem(GameContext context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PlayECSStartHorizontalMovement);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayECSStartHorizontalMovement;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                StartHorizontalMovementComponent startMovementComponent = e.playECSStartHorizontalMovement;
                HorizontalMovableComponent movableComponent = e.playECSHorizontalMovable;

                float startX = movableComponent.Transform.localPosition.x;
                float endX = startMovementComponent.TargetX;
                int direction = endX > startX ? 1 : -1;
                float movingTimeLeft = Mathf.Abs((endX - startX) / movableComponent.Speed);

                e.AddPlayECSHorizontalMoving(direction, movingTimeLeft, startMovementComponent.Callback);
                e.RemovePlayECSStartHorizontalMovement();
            }
        }
    }
}