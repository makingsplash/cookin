using Entitas;

namespace Play.ECS
{
    [Game]
    public class TimerViewComponent : IComponent
    {
        public float MaxTime;
        public float CurrentTime = 0;
        public bool Finished;
        public UpdatableViewBehaviour UpdatableView;
    }
}