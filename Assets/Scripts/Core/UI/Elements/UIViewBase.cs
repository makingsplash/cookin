using Core.UI.Camera;
using UnityEngine;

namespace Core.UI.Elements
{
    [RequireComponent(typeof(Canvas))]
    public abstract class UIViewBase : UIElement
    {
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;

        protected UIViewBasePresenter Presenter;

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = GetComponent<Canvas>();
                }

                return _canvas;
            }
        }

        public virtual void Initialize(UIViewBasePresenter presenter)
        {
            Presenter = presenter;
            SetCamera();
        }

        private void SetCamera()
        {
            if (_canvas == null)
            {
                return;
            }

            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = UICamera.Instance.Camera;
            _canvas.planeDistance = UICamera.UI_PLANE_DISTANCE;
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