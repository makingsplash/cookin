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
        private Transform _characterTransform;

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
                _orderText.text = "Привет, педики!\nМне нада капучину:\n" + string.Join("\n", Entity.playECSOrderedGuest.Order.Ingredients);
                _orderRoot.SetActive(true);
            }
        }

        public void SetWalkOutState()
        {
            _characterTransform.localScale = new Vector3(-1, 1, 1);
            _orderText.text = "Спасибо, пока педики!";
        }
    }
}