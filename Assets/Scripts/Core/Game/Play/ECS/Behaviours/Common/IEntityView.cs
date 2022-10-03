using Entitas;
using UnityEngine;

namespace Play.ECS.Common
{
    public interface IEntityView
    {
        void Link(IEntity entity);
        GameObject GameObject { get; }
        GameEntity Entity { get; }
    }
}