// ApplicationModel.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using Core.Configs;
using Core.Crypto;
using Core.Serialization;
using RPG.Domain.Player.Impl;

namespace RPG
{
    internal sealed class ApplicationModel : Config<ApplicationModel, JSONNetSerializationPolicy, RAWEncryptionProvider>
    {
        public static readonly String EnLanguageKey = "en";
        
        public const String ApplicationName = "RPG Game";
        
        public String Language;
        public Player Player;
        public Boolean IsSoundEnabled;
        public Boolean IsMusicEnabled;

        public ApplicationModel()
        {
        }


        public override ApplicationModel LoadDefault()
        {
            ApplicationModel config = new ApplicationModel();

            config.Language = EnLanguageKey;
            config.Player = new Player("Guest", 3, 90);
            config.IsSoundEnabled = true;
            config.IsMusicEnabled = true;

            return config;
        }

        protected override String GetName()
        {
            return "rpgio";
        }
    }
}