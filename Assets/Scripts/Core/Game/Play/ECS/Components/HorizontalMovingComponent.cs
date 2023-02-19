using System;
using Entitas;
using UnityEngine;

namespace Play.ECS
{
    [Game]
    public class HorizontalMovingComponent : IComponent
    {
        public Transform Transform;
        public int Direction;
        public float Speed;
        public float MovingTimeLeft;
        public Action Callback;
    }
}