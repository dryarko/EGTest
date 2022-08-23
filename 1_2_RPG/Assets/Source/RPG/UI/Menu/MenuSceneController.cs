// MenuSceneController.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.SceneTransition;
using Core.UI;
using RPG.Configs;
using RPG.UI.Character;
using RPG.UI.PopUps.Errors;
using UnityEngine;

namespace RPG.UI.Menu
{
    [SceneName("Menu")]
    internal sealed class MenuSceneController : UISceneController
    {
        private static readonly String NotSupportedMessage = "Sorry! Not yet supported :(";
        
        [SerializeField]
        private MenuView _view;
        
        private MenuModel _model;

        private LocalisationConfig Localisation
        {
            get { return ApplicationController.Instance.Configs.Localisation; }
        } 

        internal MenuSceneController()
        {
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            
            _model = new MenuModel(Localisation.StartGameText,
                Localisation.OpenCharacterText,
                Localisation.SettingsText);
            _view.Model = _model;
        }

        /// <inheritdoc />
        protected override void OnStart()
        {
            base.OnStart();

            _view.StartGame += OnStartGame;
            _view.OpenSettings += OnOpenSettings;
            _view.OpenCharacter  += OnOpenCharacter; 
        }

        protected override void OnRelease()
        {
            _view.StartGame -= OnStartGame;
            _view.OpenSettings -= OnOpenSettings;
            _view.OpenCharacter -= OnOpenCharacter;
            
            base.OnRelease();
        }

        private void OnStartGame()
        {
            OpenNotSupportedPopUp();
        }

        private void OnOpenSettings()
        {
            OpenNotSupportedPopUp();
        }
        
        private void OnOpenCharacter()
        {
            UIManager.Instance.LoadLevel<CharacterSceneController>();
        }

        private void OpenNotSupportedPopUp()
        {
            ErrorPopUpController popUp = OpenPopUp<ErrorPopUpController>(NotSupportedMessage);
            _view.AddPopUp(popUp);
        }
    }
}