namespace Core.UI.Elements.Base
{
    public abstract class UIViewBase : UIElement
    {
        protected UIViewBasePresenter Presenter;

        public virtual void Initialize(UIViewBasePresenter presenter)
        {
            Presenter = presenter;
        }

        public virtual void Show()
        {
            Presenter.OnShow?.Invoke();

            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            Presenter.OnClose?.Invoke();

            gameObject.SetActive(false);

            Destroy(gameObject);
        }

        public virtual void Clear()
        {
            Presenter.OnShow = null;
            Presenter.OnClose = null;
        }

        protected virtual void OnDestroy()
        {
            Clear();
        }
    }
}