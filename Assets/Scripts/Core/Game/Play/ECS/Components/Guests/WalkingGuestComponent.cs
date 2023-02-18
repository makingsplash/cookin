using Entitas;

namespace Play.ECS
{
    [Game]
    public class WalkingGuestComponent : IComponent
    {
        public GuestViewBehaviour View;
        public int Direction;
        public float Speed;
        public float WalkingTimeLeft;
    }
}