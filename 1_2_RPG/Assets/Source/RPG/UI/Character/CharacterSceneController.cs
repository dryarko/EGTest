// CharacterSceneController.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using System.Collections.Generic;
using Core.SceneTransition;
using Core.UI;
using RPG.Configs;
using RPG.Domain.Abilities;
using RPG.Domain.Abilities.Impl;
using RPG.Domain.Items;
using RPG.Domain.Items.Impl;
using RPG.UI.Menu;
using RPG.UI.PopUps.Info;
using UnityEngine;

namespace RPG.UI.Character
{
    [SceneName("Character")]
    internal sealed class CharacterSceneController : UISceneController
    {
        [SerializeField]
        private CharacterView _view;
        
        private CharacterModel _model;

        private LocalisationConfig Localisation
        {
            get { return ApplicationController.Instance.Configs.Localisation; }
        }

        internal CharacterSceneController()
        {
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            
            _model = new CharacterModel();
            _model.BackLocalisedText = Localisation.BackText;
            _model.LevelTextFormat = Localisation.LevelTextFormat;
            _model.ScoreTextFormat = Localisation.ScoreTextFormat;
            _model.Name = ApplicationController.Instance.Model.Player.Name;
            _model.Level = ApplicationController.Instance.Model.Player.Level;
            _model.Score = ApplicationController.Instance.Model.Player.Score;

            _model.Abilities = new List<Ability>(ApplicationController.Instance.Configs.Abilities.Abilities.Values);
            _model.Items = new List<Item>(ApplicationController.Instance.Configs.Items.Items.Values);
            
            _view.Model = _model;
        }

        /// <inheritdoc />
        protected override void OnStart()
        {
            base.OnStart();

            _view.GoBack += OnOpenMenu;
            _view.ItemClicked += OnItemClicked;
            _view.AbilityClicked += OnAbilityClicked;
        }

        /// <inheritdoc />
        protected override void OnRelease()
        {
            _view.GoBack -= OnOpenMenu;
            _view.ItemClicked -= OnItemClicked;
            _view.AbilityClicked -= OnAbilityClicked;
            
            base.OnRelease();
        }
        
        private void OnOpenMenu()
        {
            UIManager.Instance.LoadLevel<MenuSceneController>();
        }

        private void OnItemClicked(IItem item)
        {
            AbilityConfig abilitiesConfig = ApplicationController.Instance.Configs.Abilities;
            if(abilitiesConfig.Abilities.ContainsKey(item.AffectedAbility))
            {
                IAbility ability = abilitiesConfig.Abilities[item.AffectedAbility];
                String itemValue = String.Format(Localisation.ItemValueFormat, item.Value, ability.Name);
                OpenInfoPopUp(item.Name, item.Description, itemValue);
            }
        }
        
        private void OnAbilityClicked(IAbility ability)
        {
            OpenInfoPopUp(ability.Name, ability.Description, ability.Value.ToString());
        }
        
        private void OpenInfoPopUp(String title, String description, String value)
        {
            InfoPopUpController popUp = OpenPopUp<InfoPopUpController>(title, description, value);
            _view.AddPopUp(popUp);
        }
    }
}