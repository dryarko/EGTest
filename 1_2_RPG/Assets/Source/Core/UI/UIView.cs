// UIView.cs
// Created by Yaroslav Nevmerzhytskyi

using Core.UI.PopUp;
using Core.Unity;
using UnityEngine;

namespace Core.UI
{
    internal class UIView : UnityBehaviour
    {
        [SerializeField]
        internal Canvas UICanvas;

        internal UIView()
        {
        }
        
        internal void AddPopUp(UIPopUpController popUp)
        {
            popUp.Transform.SetParent(UICanvas.transform, false);
            popUp.Transform.localScale = Vector3.one;
        }
    }
}