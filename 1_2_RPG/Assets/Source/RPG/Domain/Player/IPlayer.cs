// IPlayer.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.Domain;

namespace RPG.Domain.Player
{
    public interface IPlayer : IDomainObject
    {
        String Name { get; set; }
        Int32 Level { get; set; }
        Int32 Score { get; set; }
    }
}