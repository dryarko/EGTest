// UIPopUpController.cs
// created by Yaroslav Nevmerzhytskyi

using System;

namespace Core.UI.PopUp
{
    internal class UIPopUpController : UIController
    {
        public event Action<UIPopUpController> Closed;

        internal UIPopUpController()
        {
        }

        public void Close()
        {
            OnClose();

            if(Closed != null)
            {
                Closed(this);
            }
        }

        protected virtual void OnClose()
        {
            UIManager.Instance.ClosePopUp();
        }
    }
}