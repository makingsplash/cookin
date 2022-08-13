using UnityEngine;

namespace Core.UI.Elements
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIElement : MonoBehaviour
    {
        private RectTransform _rectTransform;

        public RectTransform RectTransform
        {
            get
            {
                _rectTransform = _rectTransform == null ? GetComponent<RectTransform>() : _rectTransform;

                return _rectTransform;
            }
        }
    }
}