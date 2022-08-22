using Core.UI.Camera;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.UI.Elements.Base
{
    [RequireComponent(typeof(RectTransform), typeof(Canvas), typeof(GraphicRaycaster))]
    public abstract class UIElement : MonoBehaviour
    {
        private UICamera UICamera { get; set; }

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

        [Inject]
        private void Inject(UICamera uiCamera)
        {
            UICamera = uiCamera;
        }

        protected virtual void Start()
        {
            SetCamera();
        }

        private void SetCamera()
        {
            Canvas.renderMode = RenderMode.ScreenSpaceCamera;
            Canvas.worldCamera = UICamera.Camera;
            Canvas.planeDistance = UICamera.UI_PLANE_DISTANCE;
        }
    }
}