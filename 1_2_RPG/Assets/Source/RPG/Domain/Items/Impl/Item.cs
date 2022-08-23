// Item.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.Observer.Impl;

namespace RPG.Domain.Items.Impl
{
    [Serializable]
    public class Item : Observable, IItem
    {
        public static readonly String ResourceFolder = "Items";
        
        public String Name { get; set; }
        public String Description { get; set; }
        public Guid AffectedAbility { get; set; }
        public Single Value { get; set; }
        public String Icon { get; set; }

        public Item()
        {
        }
        
        public Item(String name, String description, Guid affectedAbility, Single value, String icon)
        {
            Name = name;
            Description = description;
            AffectedAbility = affectedAbility;
            Value = value;
            Icon = icon;
        }
    }
}