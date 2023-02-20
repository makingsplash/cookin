using System;
using Entitas;

namespace Play.ECS
{
    [Game]
    public class HorizontalMovingComponent : IComponent
    {
        public int Direction;
        public float MovingTimeLeft;
        public Action Callback;
    }
}