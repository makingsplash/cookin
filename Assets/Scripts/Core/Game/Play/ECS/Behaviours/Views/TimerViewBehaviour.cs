using Play.ECS.Common;
using TMPro;
using UnityEngine.UI;

namespace Play.ECS
{
    public class TimerViewBehaviour : EntityViewBehaviour
    {
        public float MaxTime;
        public bool AutoStart;
        public TextMeshProUGUI Text;
        public Button StartButton;

        public override void Initialize(GameContext context)
        {
            base.Initialize(context);
            Entity.AddPlayECSTimerView(this);
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

        private void Start()
        {
            StartButton?.onClick.AddListener(StartTimer);

            if (AutoStart)
            {
                StartTimer();
            }
        }
    }
}