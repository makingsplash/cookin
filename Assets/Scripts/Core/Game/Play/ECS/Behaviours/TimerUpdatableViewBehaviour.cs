using TMPro;
using UnityEngine.UI;

namespace Play.ECS
{
    public class TimerUpdatableViewBehaviour : UpdatableViewBehaviour
    {
        public float MaxTime;
        public bool AutoStart;
        public TextMeshProUGUI Text;
        public Button StartButton;

        public GameEntity GameEntity => _gameEntity;

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
            if (!GameEntity.hasPlayECSRunningTimer)
            {
                GameEntity.AddPlayECSRunningTimer(MaxTime, 0.0f);
            }
        }

        public override void UpdateView()
        {
            if (!_gameEntity.isPlayECSFinishedTimer)
            {
                Text.text = _gameEntity.playECSRunningTimer.CurrentTime.ToString("F");
            }
        }

        public void ResetView()
        {
            Text.text = string.Empty;
        }
    }
}