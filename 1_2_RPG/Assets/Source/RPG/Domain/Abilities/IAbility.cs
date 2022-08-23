// IAbility.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.Observer;

namespace RPG.Domain.Abilities
{
    public interface IAbility : IObservable
    {
        String Name { get; set; }
        String Description { get; set; }
        Single Value { get; set; }
    }
}