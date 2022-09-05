using System;

namespace Core.UI.Elements.Base
{
    public abstract class UIViewBasePresenter
    {
        public Action OnShow;
        public Action OnClose;

        public string PrefabPath { get; }

        protected UIViewBase View;

        public UIViewBasePresenter(string prefabPath)
        {
            PrefabPath = prefabPath;
        }

        public virtual void SetView(UIViewBase viewBase)
        {
            View = viewBase;
            View.Initialize(this);
        }

        public abstract void InitializeView();
    }
}