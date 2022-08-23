// LocalizationConfig.cs
// Created by Yaroslav Nevmerzhytskiy
// yaroslav@elevenpillars.com
// Copyright 2018 ELEVEN PILLARS

using System;
using Core.Configs;
using Core.Crypto;
using Core.Serialization;

namespace RPG.Configs
{
	public sealed class LocalisationConfig : Config<LocalisationConfig, JSONNetSerializationPolicy, RAWEncryptionProvider>
	{
		public const String FileName = "localization.xml";

#region Loading
		public String LoadingTitle;
#endregion

#region Menu
		public String OpenCharacterText;
		public String StartGameText;
		public String SettingsText;
#endregion

#region Character
		public String BackText;
		public String AbilitiesText;
		public String LevelTextFormat;
		public String ScoreTextFormat;
		public String ItemValueFormat;
#endregion

#region PopUps
		public String ErrorPopUpTitle;
		public String CloseText;
#endregion

		public LocalisationConfig()
		{
		}

		protected override String GetName()
		{
			return FileName;
		}

		public override LocalisationConfig LoadDefault()
		{
			LocalisationConfig config = new LocalisationConfig();
			
			// Loading
			config.LoadingTitle = "LOADING";
			
			// Menu
			config.OpenCharacterText = "Your Character";
			config.StartGameText = "Start Game";
			config.SettingsText = "Settings";
			
			// Character
			config.BackText = "Back";
			config.AbilitiesText = "Your abilities";
			config.LevelTextFormat = "Lvl {0}";
			config.ScoreTextFormat = "Score {0}";
			config.ItemValueFormat = "+{0} to {1}";
			
			// PopUps
			config.ErrorPopUpTitle = "Attention!";
			config.CloseText = "Close";
			
			return config;
		}
	}
}