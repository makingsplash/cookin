using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Play.ECS.Common
{
    public class EntityViewBehaviour : MonoBehaviour, IEntityView
    {
        public GameObject GameObject => gameObject;
        public GameEntity Entity => _entity;

        private GameEntity _entity;


        public void Link(IEntity entity)
        {
            _entity = (GameEntity) entity;
            gameObject.Link(_entity);

            _entity.OnDestroyEntity += OnDestroyEntity;
        }

        private void OnDestroyEntity(IEntity entity)
        {
            _entity.OnDestroyEntity -= OnDestroyEntity;
            gameObject.Unlink();
        }
    }
}