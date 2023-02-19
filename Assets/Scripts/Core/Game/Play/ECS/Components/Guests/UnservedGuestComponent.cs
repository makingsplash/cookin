using Entitas;

namespace Play.ECS
{
    [Game]
    public class UnservedGuestComponent : IComponent
    {
        public GuestViewBehaviour View;
    }
}