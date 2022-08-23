// ErrorPopUpController.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using Core.UI.PopUp;
using RPG.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

namespace RPG.UI.PopUps.Errors
{
    internal sealed class ErrorPopUpController : UIPopUpController
    {
        [SerializeField]
        private TMP_Text _titleLabel;
        [SerializeField]
        private TMP_Text _messageLabel;

        [SerializeField]
        private Button _backButton;
        [SerializeField]
        private TMP_Text _backButtonText;

        protected override void OnStart(params Object[] args)
        {
            base.OnStart(args);

            String message = (String)args[0];
            LocalisationConfig localisation = ApplicationController.Instance.Configs.Localisation;

            _titleLabel.text = localisation.ErrorPopUpTitle;
            _messageLabel.text = message;
            _backButtonText.text = localisation.CloseText;
            
            _backButton.onClick.AddListener(Close);
        }

        protected override void OnRelease()
        {
            _backButton.onClick.RemoveListener(Close);
            
            base.OnRelease();
        }
    }
}