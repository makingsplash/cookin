using Play.ECS.Common;
using TMPro;
using UnityEngine.UI;

namespace Play.ECS
{
    public class TimerViewBehaviourBehaviour : EntityViewBehaviour
    {
        public float MaxTime;
        public bool AutoStart;
        public TextMeshProUGUI Text;
        public Button StartButton;

        private void Start()
        {
            StartButton?.onClick.AddListener(StartTimer);

            if (AutoStart)
            {
                StartTimer();
            }
        }

        public void StartTimer()
        {
            if (!Entity.hasPlayECSRunningTimer)
            {
                Entity.AddPlayECSRunningTimer(MaxTime, 0.0f);
            }
        }

        public void UpdateView()
        {
            if (!Entity.isPlayECSFinishedTimer)
            {
                Text.text = Entity.playECSRunningTimer.CurrentTime.ToString("F");
            }
        }

        public void ResetView()
        {
            Text.text = string.Empty;
        }
    }
}