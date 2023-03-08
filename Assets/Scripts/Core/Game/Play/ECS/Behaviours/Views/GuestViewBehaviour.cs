using System;
using System.Collections.Generic;
using Entitas;
using Play.ECS.Common;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
        private static readonly List<int> WalkingAnimationHashes = new List<int>
        {
            Animator.StringToHash("Walking1"),
            Animator.StringToHash("Walking2"),
            Animator.StringToHash("Walking3"),
        };

        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Transform _characterTransform;

        [SerializeField]
        private Image _characterImage;

        [SerializeField]
        private GameObject _speechBubble;

        [SerializeField]
        private float _movingSpeed;

        [SerializeField]
        private Transform _ingrevientsViewRoot;

        private int _currentWalkingAnimationHash;


        public override void Initialize(GameContext context)
        {
            base.Initialize(context);
            Entity.AddPlayECSGuestView(this, null);
            Entity.AddPlayECSGuestOrder(null);
            Entity.AddPlayECSHorizontalMovable(transform, _movingSpeed);

            Entity.OnComponentAdded += OnMoving;
            Entity.OnComponentAdded += OnOrdered;

            SetOrderRootActive(false);
        }

        private void SetState(GuestState state)
        {
            switch (state)
            {
                case GuestState.WalkIn:
                    SetWalkInAnimation();
                    break;
                case GuestState.Ordered:
                    SpawnOrder();
                    SetOrderRootActive(true);
                    StopWalkingAnimation();
                    break;
                case GuestState.WalkOut:
                    SetOrderRootActive(false);
                    SetFadeColor();
                    SetWalkOutAnimation();
                    _characterTransform.localScale = new Vector3(-1, 1, 1);
                    _canvas.sortingOrder = 6;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void SpawnOrder()
        {
            Entity.AddPlayECSSpawnIngredientViews(Entity.playECSOrderedGuest.Order.Ingredients, _ingrevientsViewRoot);
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

        private void SetWalkInAnimation()
        {
            int animIndex = Random.Range(0, WalkingAnimationHashes.Count);

            _currentWalkingAnimationHash = WalkingAnimationHashes[animIndex];

            _animator.SetBool(_currentWalkingAnimationHash, true);
        }

        private void StopWalkingAnimation()
        {
            _animator.SetBool(_currentWalkingAnimationHash, false);
        }

        private void SetWalkOutAnimation()
        {
            _animator.SetBool(WalkingAnimationHashes[0], true);
        }

        private void SetOrderRootActive(bool active)
        {
            _speechBubble.SetActive(active);
        }

        private void SetFadeColor()
        {
            ColorUtility.TryParseHtmlString("#595959", out Color fadeColor);
            _characterImage.color = fadeColor;
        }

        protected override void OnDestroyEntity(IEntity entity)
        {
            Entity.OnComponentAdded -= OnMoving;
            Entity.OnComponentAdded -= OnOrdered;
            base.OnDestroyEntity(entity);
        }
    }
}