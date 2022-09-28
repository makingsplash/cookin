using TMPro;

namespace Play.ECS
{
    public class TimerUpdatableViewBehaviour : UpdatableViewBehaviour
    {
        public TextMeshProUGUI Text;

        public override void UpdateView()
        {
            Text.text = _gameEntity.playECSTimerView.CurrentTime.ToString("F1");
        }
    }
}