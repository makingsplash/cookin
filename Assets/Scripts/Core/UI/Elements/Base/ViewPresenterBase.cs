namespace Core.UI.Elements.Base
{
    public abstract class ViewPresenterBase
    {
        public string PrefabPath { get; }

        public ViewBase View;

        protected ViewPresenterBase(string prefabPath)
        {
            PrefabPath = prefabPath;
        }

        public virtual void InitializeView()
        {
            BindView();
        }

        protected virtual void BindView()
        {
        }
    }
}