// MenuView.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI.Menu
{
    internal sealed class MenuView : UIViewWithModel<MenuModel>
    {
        public event Action StartGame;
        public event Action OpenSettings;
        public event Action OpenCharacter;

        [SerializeField]
        private Button _startGameButton;
        [SerializeField]
        private TMP_Text _startGameButtonText;
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private TMP_Text _settingsButtonText;
        [SerializeField]
        private Button _openCharacterButton;
        [SerializeField]
        private TMP_Text _openCharacterText;
        [SerializeField]
        private TMP_Text _applicationNameText;

        internal MenuView()
        {
        }

        /// <inheritdoc />
        protected override void OnStart()
        {
            base.OnStart();

            _applicationNameText.text = ApplicationModel.ApplicationName;

            _startGameButton.onClick.AddListener(OnStartGamePressed);
            _settingsButton.onClick.AddListener(OnSettingsButtonPressed);
            _openCharacterButton.onClick.AddListener(OnOpenCharacterButtonPressed);

            _startGameButtonText.text = Model.StartGameLocalisedText;
            _settingsButtonText.text = Model.SettingsLocalisedText;
            _openCharacterText.text = Model.OpenCharacterLocalisedText;
        }

        protected override void OnRelease()
        {
            _startGameButton.onClick.RemoveListener(OnStartGamePressed);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonPressed);
            _openCharacterButton.onClick.RemoveListener(OnOpenCharacterButtonPressed);
            
            base.OnRelease();
        }
        
        private void OnStartGamePressed()
        {
            if(StartGame != null)
            {
                StartGame();
            }
        }
        
        private void OnSettingsButtonPressed()
        {
            if(OpenSettings != null)
            {
                OpenSettings();
            }
        }
        
        private void OnOpenCharacterButtonPressed()
        {
            if(OpenCharacter != null)
            {
                OpenCharacter();
            }
        }
    }
}