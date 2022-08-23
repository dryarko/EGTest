// Ability.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.Observer.Impl;

namespace RPG.Domain.Abilities.Impl
{
    [Serializable]
    internal class Ability : Observable, IAbility
    {
        public static readonly String ResourceFolder = "Abilities";
        
        public String Name { get; set; }
        public String Description { get; set; }
        public Single Value { get; set; }
        public String Icon { get; set; }

        internal Ability()
        {   
        }

        internal Ability(String name, String description, Single value, String icon)
        {
            Name = name;
            Description = description;
            Value = value;
            Icon = icon;
        }
    }
}