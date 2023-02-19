using System;
using Play.ECS.Common;
using TMPro;
using UnityEngine;

namespace Play.ECS
{
    public enum GuestState
    {
        WalkIn,
        Arrived,
        WalkOut
    }

    public class GuestViewBehaviour : EntityViewBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private GameObject _orderRoot;

        [SerializeField]
        private Transform _characterTransform;

        [SerializeField]
        private TextMeshProUGUI _orderText;

        private static readonly int Walking = Animator.StringToHash("Walking");

        public override void Initialize(GameContext context)
        {
            base.Initialize(context);
            Entity.AddPlayECSGuestView(this);
            Entity.AddPlayECSUnservedGuest(this);
        }

        public void SetState(GuestState state)
        {
            switch (state)
            {
                case GuestState.WalkIn:
                    SetWalkingAnimation(true);
                    break;
                case GuestState.Arrived:
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
    }
}