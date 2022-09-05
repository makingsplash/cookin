using Core.UI.Elements.Base;

namespace Core.UI.Elements.Popup
{
    public abstract class PopupViewPresenter : UIViewBasePresenter
    {
        private PopupView PopupView => View as PopupView;

        public PopupViewPresenter(string prefabPath) : base(prefabPath)
        {
        }
    }
}