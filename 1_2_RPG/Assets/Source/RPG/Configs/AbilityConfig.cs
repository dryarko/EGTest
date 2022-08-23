// AbilityConfig.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.Collections.Generic;
using Core.Configs;
using Core.Crypto;
using Core.Serialization;
using RPG.Domain.Abilities.Impl;

namespace RPG.Configs
{
    internal class AbilityConfig : Config<AbilityConfig, JSONNetSerializationPolicy, RAWEncryptionProvider>
    {
        private static readonly String FileName = "Abilities";

        public Dictionary<Guid, Ability> Abilities;

        public AbilityConfig()
        {
            Abilities = new Dictionary<Guid, Ability>();
        }

        /// <inheritdoc />
        protected override String GetName()
        {
            return FileName;
        }

        /// <inheritdoc />
        public override AbilityConfig LoadDefault()
        {
            AbilityConfig config = new AbilityConfig();

            config.Abilities.Add(Guid.Parse("14c9beab-69a6-47d9-b61d-1b7f6fc4dbeb"), 
                new Ability("Health", "Ability of the character to withstand damage", 100f, "heart-wings"));
            config.Abilities.Add(Guid.Parse("4d9dc178-4b8d-4579-9e54-2ededbbc9b29"),
                new Ability("Armor", "Ability of the character to reflect damage", 11.3f, "griffin-shield"));
            config.Abilities.Add(Guid.Parse("4ed30ddc-ac47-4c4c-9b04-1d2abd096976"),
                new Ability("Agility", "Defines how long the character can run until exhausted", 5f, "running-shoe"));
            config.Abilities.Add(Guid.Parse("f6780c5d-c7ca-4cf6-b74e-da1cc568c839"),
                new Ability("Strength", "Defines how much damage is dealt by the character", 23f, "strong-man"));
            

            return config;
        }
    }
}