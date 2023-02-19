using System.Collections.Generic;
using Entitas;
using Play.ECS;
using UnityEngine;

namespace Core.Game.Play.ECS.Systems.ExecuteSystems
{
    public class HorizontalMoveSystem : IExecuteSystem
    {
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new();

        public HorizontalMoveSystem(GameContext context)
        {
            _context = context;
            _group = _context.GetGroup(GameMatcher.PlayECSHorizontalMoving);
        }

        public void Execute()
        {
            foreach (var e in _group.GetEntities(_buffer))
            {
                HorizontalMovingComponent movingComponent = e.playECSHorizontalMoving;

                if (movingComponent.MovingTimeLeft > 0)
                {
                    movingComponent.MovingTimeLeft -= Time.deltaTime;

                    movingComponent.Transform.localPosition += new Vector3(movingComponent.Direction * movingComponent.Speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    movingComponent.Callback?.Invoke();
                    e.RemovePlayECSHorizontalMoving();
                }
            }
        }
    }
}