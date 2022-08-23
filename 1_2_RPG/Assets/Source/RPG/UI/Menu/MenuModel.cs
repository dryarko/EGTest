// MenuModel.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.Observer.Impl;

namespace RPG.UI.Menu
{
    internal sealed class MenuModel : Observable
    {
        public String StartGameLocalisedText;
        public String OpenCharacterLocalisedText;
        public String SettingsLocalisedText;

        public MenuModel(String startGameLocalisedText, String openCharacterLocalisedText, String settingsLocalisedText)
        {
            StartGameLocalisedText = startGameLocalisedText;
            OpenCharacterLocalisedText = openCharacterLocalisedText;
            SettingsLocalisedText = settingsLocalisedText;
        }
    }
}