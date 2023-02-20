using Entitas;
using UnityEngine;

namespace Play.ECS
{
    [Game]
    public class HorizontalMovableComponent : IComponent
    {
        public Transform Transform;
        public float Speed;
    }
}