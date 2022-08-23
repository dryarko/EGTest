// InfoPopUpController.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using Core.UI.PopUp;
using RPG.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

namespace RPG.UI.PopUps.Info
{
    internal sealed class InfoPopUpController : UIPopUpController
    {
        [SerializeField]
        private TMP_Text _titleLabel;
        [SerializeField]
        private TMP_Text _descriptionLabel;
        [SerializeField]
        private TMP_Text _valueLabel;

        [SerializeField]
        private Button _backButton;
        [SerializeField]
        private TMP_Text _backButtonText;

        protected override void OnStart(params Object[] args)
        {
            base.OnStart(args);

            String title = (String)args[0];
            String description = (String)args[1];
            String value = (String)args[2];

            LocalisationConfig localisation = ApplicationController.Instance.Configs.Localisation;
            
            _titleLabel.text = title;
            _descriptionLabel.text = description;
            _valueLabel.text = value;
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