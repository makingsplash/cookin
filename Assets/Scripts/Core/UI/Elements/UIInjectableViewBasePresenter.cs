using Core.UI.Elements;

namespace Core.UI.UIElementsBase
{
    public class UIInjectableViewBasePresenter : UIViewBasePresenter
    {
        public string RootID;

        public UIInjectableViewBasePresenter(string prefabPath, string rootID) : base(prefabPath)
        {
            RootID = rootID;
        }
    }
}