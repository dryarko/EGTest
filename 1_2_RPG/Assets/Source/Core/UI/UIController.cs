// UIController.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.UI.PopUp;
using Core.Unity;

namespace Core.UI
{
    internal class UIController : UnityBehaviour
    {
        internal UIController()
        {
        }

        protected override void OnStart()
        {
            base.OnStart();

            UIManager.Instance.RegisterController(this);
            Object[] args = UIManager.Instance.GetArgs();
            if(args != null)
            {
                OnStart(args);
            }
        }

        protected virtual void OnStart(params Object[] args)
        {
        }

        protected TPopUpController OpenPopUp<TPopUpController>(params Object[] args)
            where TPopUpController : UIPopUpController
        {
            return UIManager.Instance.OpenPopUp<TPopUpController>(args);
        }

        protected UIPopUpController OpenPopUp(Type type, params Object[] args)
        {
            return UIManager.Instance.OpenPopUp(type, args);
        }
    }
}