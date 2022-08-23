// CharacterView.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using System.Collections.Generic;
using Core.UI;
using RPG.Domain.Abilities;
using RPG.Domain.Abilities.Impl;
using RPG.Domain.Items;
using RPG.Domain.Items.Impl;
using RPG.UI.Character.Abilities;
using RPG.UI.Character.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI.Character
{
    internal sealed class CharacterView : UIViewWithModel<CharacterModel>
    {
        public event Action GoBack;
        public event Action<IAbility> AbilityClicked;
        public event Action<IItem> ItemClicked;
        
        [SerializeField]
        private Button _backButton;
        [SerializeField]
        private TMP_Text _backButtonText;
        
        [SerializeField]
        private List<AbilityView> _abilityViews;
        [SerializeField]
        private List<ItemView> _itemViews;
        
        [SerializeField]
        private TMP_Text _nameText;
        [SerializeField]
        private TMP_Text _levelText;
        [SerializeField]
        private TMP_Text _scoreText;
        
        /// <inheritdoc />
        protected override void OnStart()
        {
            base.OnStart();

            _backButton.onClick.AddListener(OnBackPressed);
            
            _backButtonText.text = Model.BackLocalisedText;
            _nameText.text = Model.Name;
            _levelText.text = String.Format(Model.LevelTextFormat, Model.Level);
            _scoreText.text = String.Format(Model.ScoreTextFormat, Model.Score);

            PopulateItems();
            PopulateAbilities();
        }

        protected override void OnRelease()
        {
            _backButton.onClick.RemoveListener(OnBackPressed);
            foreach(ItemView itemView in _itemViews)
            {
                itemView.ButtonClicked -= OnCellClicked;
            }
            _itemViews.Clear();
            _itemViews = null;

            foreach(AbilityView abilityView in _abilityViews)
            {
                abilityView.ButtonClicked -= OnCellClicked;   
            }
            _abilityViews.Clear();
            _abilityViews = null;
            
            base.OnRelease();
        }
        
        private void OnBackPressed()
        {
            GoBack?.Invoke();
        }

        private void PopulateItems()
        {
            for(Int32 i = 0; i < Math.Min(Model.Items.Count, _itemViews.Count); i++)
            {
                Item item = Model.Items[i];
                _itemViews[i].Model = item;
                _itemViews[i].ButtonClicked += OnCellClicked;
            }
        }
        
        private void PopulateAbilities()
        {
            for(Int32 i = 0; i < Math.Min(Model.Abilities.Count, _abilityViews.Count); i++)
            {
                Ability ability = Model.Abilities[i];
                _abilityViews[i].Model = ability;
                _abilityViews[i].ButtonClicked += OnCellClicked;
            }
        }

        private void OnCellClicked<T>(T model)
        {
            if(model is IAbility ability)
            {
                AbilityClicked?.Invoke(ability);
            }
            else if(model is IItem item)
            {
                ItemClicked?.Invoke(item);
            }
        }
    }
}