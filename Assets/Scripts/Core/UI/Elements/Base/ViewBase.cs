using System;

namespace Core.UI.Elements.Base
{
    public abstract class ViewBase : UIElement
    {
        public Action OnShow;
        public Action OnClose;

        public virtual void Show()
        {
            OnShow?.Invoke();

            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            OnClose?.Invoke();

            gameObject.SetActive(false);

            Destroy(gameObject);
        }

        public virtual void Clear()
        {
            OnShow = null;
            OnClose = null;
        }

        protected virtual void OnDestroy()
        {
            Clear();
        }
    }
}