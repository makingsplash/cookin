using Entitas;
using UnityEngine;

namespace Play.ECS
{
    public abstract class UpdatableViewBehaviour : MonoBehaviour
    {
        protected GameEntity _gameEntity;

        public void Link(IEntity entity)
        {
            _gameEntity = (GameEntity) entity;
        }

        public virtual void UpdateView()
        {

        }
    }
}