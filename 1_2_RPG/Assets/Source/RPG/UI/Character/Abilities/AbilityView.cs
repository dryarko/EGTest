// AbilityView.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using System.IO;
using Core.UI;
using RPG.Domain.Abilities.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI.Character.Abilities
{
    [Serializable]
    internal class AbilityView : UIViewWithButtonAndModel<Ability>
    {
        [SerializeField]
        private Image Icon;

        protected override void ApplyModel()
        {
            base.ApplyModel();
            
            SetSprite();
        }

        protected override void OnModelChanged()
        {
            base.OnModelChanged();

            SetSprite();
        }

        private void SetSprite()
        {
            Icon.sprite = Resources.Load<Sprite>(Path.Combine(Ability.ResourceFolder, Model.Icon));
        }
    }
}