using System;
using Entitas;
using Play.ECS.Common;
using TMPro;
using UnityEngine;

namespace Play.ECS
{
    public enum GuestState
    {
        WalkIn,
        Ordered,
        WalkOut
    }

    public class GuestViewBehaviour : EntityViewBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Transform _characterTransform;

        [SerializeField]
        private GameObject _orderRoot;

        [SerializeField]
        private TextMeshProUGUI _orderText;

        [SerializeField]
        private float _movingSpeed;

        private static readonly int Walking = Animator.StringToHash("Walking");

        public override void Initialize(GameContext context)
        {
            base.Initialize(context);
            Entity.AddPlayECSGuestView(this);
            Entity.AddPlayECSUnservedGuest(Entity);
            Entity.AddPlayECSHorizontalMovable(transform, _movingSpeed);

            Entity.OnComponentAdded += OnMoving;
            Entity.OnComponentAdded += OnOrdered;
        }

        private void SetState(GuestState state)
        {
            switch (state)
            {
                case GuestState.WalkIn:
                    SetWalkingAnimation(true);
                    break;
                case GuestState.Ordered:
                    SetOrderText("Привет, педики!\nМне нада капучину:\n" + string.Join("\n", Entity.playECSOrderedGuest.Order.Ingredients));
                    SetOrderTextActive(true);
                    SetWalkingAnimation(false);
                    break;
                case GuestState.WalkOut:
                    SetOrderText("Спасибо, пока педики!");
                    SetWalkingAnimation(true);
                    _characterTransform.localScale = new Vector3(-1, 1, 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void OnMoving(IEntity entity, int index, IComponent component)
        {
            if (component is HorizontalMovingComponent movingComponent)
            {
                SetState(movingComponent.Direction > 0 ? GuestState.WalkIn : GuestState.WalkOut);
            }
        }

        private void OnOrdered(IEntity entity, int index, IComponent component)
        {
            if (component is OrderedGuestComponent)
            {
                SetState(GuestState.Ordered);
            }
        }

        private void SetWalkingAnimation(bool value)
        {
            _animator.SetBool(Walking, value);
        }

        private void SetOrderTextActive(bool active)
        {
            _orderRoot.SetActive(active);
        }

        private void SetOrderText(string text)
        {
            _orderText.text = text;
        }

        protected override void OnDestroyEntity(IEntity entity)
        {
            Entity.OnComponentAdded -= OnMoving;
            Entity.OnComponentAdded -= OnOrdered;
            base.OnDestroyEntity(entity);
        }
    }
}