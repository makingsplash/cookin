using System;

namespace Core.UI.Elements
{
    public abstract class UIViewBasePresenter
    {
        public Action OnShow;
        public Action OnHide;

        public Action OnShown;
        public Action OnHidden;

        public Action OnDestroyed;

        public string PrefabPath { get; }

        protected UIViewBase View;

        public UIViewBasePresenter(string prefabPath)
        {
            PrefabPath = prefabPath;
        }

        public virtual void SetupView(UIViewBase viewBase)
        {
            View = viewBase;
            View.Initialize(this);
        }
    }
}