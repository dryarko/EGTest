// PrefabConfiguration.cs
// Created by Yaroslav Nevmerzhytskyi

using RPG.UI.Character.Abilities;
using RPG.UI.Character.Items;
using UnityEngine;

namespace RPG.Configuration
{
    [CreateAssetMenu(menuName = "RPG/Create Prefab Configuration", fileName = "PrefabConfiguration")]
    internal sealed class PrefabConfiguration : ScriptableObject
    {
        public AbilityView AbilityView;
        public ItemView ItemView;
    }
}