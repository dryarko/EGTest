// CharacterModel.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using System.Collections.Generic;
using Core.Observer.Impl;
using RPG.Domain.Abilities.Impl;
using RPG.Domain.Items.Impl;

namespace RPG.UI.Character
{
    internal sealed class CharacterModel : Observable
    {
        public String BackLocalisedText;
        public String Name;
        public String LevelTextFormat;
        public String ScoreTextFormat;
        
        public Int32 Level;
        public Int32 Score;
        
        public List<Item> Items;
        public List<Ability> Abilities;
    }
}