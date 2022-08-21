namespace Core.UI.Elements
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

            Presenter.OnShown?.Invoke();
        }

        public virtual void Hide()
        {
            Presenter.OnHide?.Invoke();

            gameObject.SetActive(false);

            Presenter.OnHidden?.Invoke();
        }

        public virtual void Clear()
        {
            Presenter.OnShow = null;
            Presenter.OnHide = null;

            Presenter.OnShown = null;
            Presenter.OnHidden = null;

            Presenter.OnDestroyed = null;
        }

        protected virtual void OnDestroy()
        {
            Presenter.OnDestroyed?.Invoke();

            Clear();
        }

        public virtual void Close()
        {
            Presenter.OnHidden?.Invoke();

            Destroy(gameObject);
        }
    }
}