namespace Core.Game.Context
{
    public abstract class Context
    {
        public virtual string Scene { get; set; }

        public virtual void Load()
        {
        }
    }
}