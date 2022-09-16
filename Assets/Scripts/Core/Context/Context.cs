using Cysharp.Threading.Tasks;

namespace Core.Context
{
    public interface IContext
    {
        string Scene { get; }

        public UniTask Setup();
    }
}