// IItem.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.Observer;

namespace RPG.Domain.Items
{
    public interface IItem : IObservable
    {
        String Name { get; set; }
        String Description { get; set; }
        Guid AffectedAbility { get; set; }
        Single Value { get; set; }
    }
}