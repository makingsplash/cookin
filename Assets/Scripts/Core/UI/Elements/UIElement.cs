using Core.UI.Camera;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Elements
{
    [RequireComponent(typeof(RectTransform), typeof(Canvas), typeof(GraphicRaycaster))]
    public abstract class UIElement : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;

        public RectTransform RectTransform
        {
            get
            {
                _rectTransform = _rectTransform == null ? GetComponent<RectTransform>() : _rectTransform;

                return _rectTransform;
            }
        }

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

        protected virtual void Awake()
        {
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
    }
}