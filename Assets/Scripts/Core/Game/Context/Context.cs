using Cysharp.Threading.Tasks;

namespace Core.Game.Context
{
    public abstract class Context
    {
        public virtual string Scene { get; }

        public virtual UniTask Setup()
        {
            return new UniTask();
        }
    }
}