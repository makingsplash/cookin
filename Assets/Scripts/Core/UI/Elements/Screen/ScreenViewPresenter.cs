using Core.UI.Elements.Base;

namespace Core.UI.Elements.Screen
{
    public abstract class ScreenViewPresenter : UIViewBasePresenter
    {
        protected ScreenView ScreenView => View as ScreenView;

        protected ScreenViewPresenter(string prefabPath) : base(prefabPath)
        {
        }

        protected override void BindView()
        {
            ScreenView.Veil.onClick.AddListener(ScreenView.Close);
        }
    }
}