// ItemView.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using System.IO;
using Core.UI;
using RPG.Domain.Items.Impl;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI.Character.Items
{
    [Serializable]
    internal class ItemView : UIViewWithButtonAndModel<Item>
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
            Icon.sprite = Resources.Load<Sprite>(Path.Combine(Item.ResourceFolder, Model.Icon));
        }
    }
}