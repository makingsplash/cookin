namespace Core.UI.Elements.Popup
{
    public abstract class PopupViewPresenter : UIViewBasePresenter
    {
        protected PopupView _popupView;

        // Inject
        public PopupViewPresenter(string prefabPath) : base(prefabPath)
        {
        }
    }
}