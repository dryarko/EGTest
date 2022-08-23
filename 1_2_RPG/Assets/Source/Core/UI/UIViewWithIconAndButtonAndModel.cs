// UIViewWithButtonAndModel.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using Core.Observer.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    internal class UIViewWithButtonAndModel<T> : UIViewWithModel<T> where T : Observable
    {
        public event Action<T> ButtonClicked;
        
        [SerializeField]
        private Button Button;

        protected override void OnStart()
        {
            base.OnStart();
            
            Button.onClick.AddListener(OnButtonClick);
        }

        protected override void OnRelease()
        {
            Button.onClick.RemoveListener(OnButtonClick);
            
            base.OnRelease();
        }

        private void OnButtonClick()
        {
            ButtonClicked?.Invoke(Model);
        }
    }
}