using Entitas;
using Play.ECS.Common;

namespace Play.ECS
{
    [Game]
    public class EntityViewComponent : IComponent
    {
        public IEntityView View;
    }
}