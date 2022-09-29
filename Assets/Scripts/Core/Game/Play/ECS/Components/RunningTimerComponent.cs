using Entitas;

namespace Play.ECS
{
    [Game]
    public class RunningTimerComponent : IComponent
    {
        public float MaxTime;
        public float CurrentTime = 0;
    }
}