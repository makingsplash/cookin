using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Play.ECS
{
    public class BlockTouchByTimerBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        public TimerViewBehaviour TimerView;

        private void Start()
        {
            if (TimerView.Entity.hasPlayECSRunningTimer)
            {
                _button.interactable = false;
            }

            TimerView.Entity.OnComponentAdded += OnComponentAdded;
        }

        private void OnComponentAdded(IEntity entity, int index, IComponent component)
        {
            _button.interactable = component switch
            {
                RunningTimerComponent => false,
                FinishedTimerComponent => true,
                _ => _button.interactable
            };
        }
    }
}