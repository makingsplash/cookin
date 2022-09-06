using Core.UI.Elements.Base;

namespace Core.UI.Elements.Popup
{
    public abstract class ScreenViewPresenter : UIViewBasePresenter
    {
        protected ScreenView ScreenView => View as ScreenView;

        public ScreenViewPresenter(string prefabPath) : base(prefabPath)
        {
        }
    }
}