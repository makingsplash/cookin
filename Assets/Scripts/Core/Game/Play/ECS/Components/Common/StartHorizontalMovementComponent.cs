using System;
using Entitas;

namespace Play.ECS
{
    [Game]
    public class StartHorizontalMovementComponent : IComponent
    {
        public float TargetX;
        public Action Callback;
    }
}