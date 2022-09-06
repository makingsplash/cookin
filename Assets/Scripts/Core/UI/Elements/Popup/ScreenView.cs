using Core.UI.Elements.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Elements.Popup
{
    [RequireComponent(typeof(GraphicRaycaster))]
    public class ScreenView : UIViewBase
    {
        [SerializeField]
        protected Button veil;

        public override void Initialize(UIViewBasePresenter presenter)
        {
            base.Initialize(presenter);

            veil.onClick.AddListener(Close);
        }
    }
}