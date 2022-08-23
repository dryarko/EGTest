// LoadingView.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI.Loading
{
    internal sealed class LoadingView : UIViewWithModel<LoadingModel>
    {
        private static readonly Int32 NumberOfDots = 3;

        [SerializeField]
        private TMP_Text _loadingText;
        [SerializeField]
        private Image _progressBar;

        private Int16 _counter;

        internal LoadingView()
        {
            _counter = 0;
        }

        /// <inheritdoc />
        protected override void OnStart()
        {
            base.OnStart();

            DelayUpdate(.3f);
        }

        /// <inheritdoc />
        protected override void OnDelayedUpdate()
        {
            base.OnDelayedUpdate();

            _loadingText.text = String.Format("{0}{1}",
                ApplicationController.Instance.Configs.Localisation.LoadingTitle, new String('.', _counter++));

            if(_counter >= NumberOfDots)
            {
                _counter = 0;
            }

            _progressBar.fillAmount = Model.Progress;
        }
    }
}