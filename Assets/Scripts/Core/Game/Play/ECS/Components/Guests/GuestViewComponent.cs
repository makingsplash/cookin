using Core.Game.Play.UI;
using Entitas;

namespace Play.ECS
{
    [Game]
    public class GuestViewComponent : IComponent
    {
        public GuestViewBehaviour View;
        public GuestSeat Seat;
    }
}