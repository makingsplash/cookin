using Play.ECS.Common;
using TMPro;
using UnityEngine;

namespace Play.ECS
{
    public class GuestViewBehaviour : EntityViewBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private GameObject _orderRoot;

        [SerializeField]
        private TextMeshProUGUI _orderText;

        private static readonly int Walking = Animator.StringToHash("Walking");

        public override void Initialize(GameContext context)
        {
            base.Initialize(context);
            Entity.AddPlayECSGuestView(this);
        }

        public void SetWalkingAnimation(bool value)
        {
            _animator.SetBool(Walking, value);
        }

        public void DisplayOrder()
        {
            if (Entity.hasPlayECSOrderedGuest)
            {
                _orderText.text = string.Join("\n", Entity.playECSOrderedGuest.Order.Ingredients);
                _orderRoot.SetActive(true);
            }
        }
    }
}