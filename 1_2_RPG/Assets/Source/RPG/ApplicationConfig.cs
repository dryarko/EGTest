// ApplicationConfig.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.IO;
using RPG.Configs;
using UnityEngine;

namespace RPG
{
    internal sealed class ApplicationConfig
    {
        public const String LocalizationConfigFolder = "localization";

        public AbilityConfig Abilities
        {
            get;
            set;
        }
        
        public ItemConfig Items
        {
            get;
            set;
        }

        public LocalisationConfig Localisation
        {
            get;
            set;
        }
        
        internal ApplicationConfig()
        {
            Abilities = new AbilityConfig();
            Items = new ItemConfig();
            Localisation = new LocalisationConfig();
        }

        public void Initialise()
        {
            Abilities = AbilityConfig.Load();
            if(Abilities == null)
            {
                Abilities = new AbilityConfig();
                Abilities = Abilities.LoadDefault();
                Abilities.Save();
            }
            
            Items = ItemConfig.Load();
            if(Items == null)
            {
                Items = new ItemConfig();
                Items = Items.LoadDefault();
                Items.Save();
            }
        }
        
        public void LoadDefault()
        {
            Abilities = Abilities.LoadDefault();
            Items = Items.LoadDefault();
            Localisation = Localisation.LoadDefault();
            
            Abilities.Save();
            Items.Save();
            Localisation.Save();
        }

        public void Load()
        {
            try
            {
                Abilities = AbilityConfig.Load();
                Items = ItemConfig.Load();
                Localisation = LocalisationConfig.Load();
            }
            catch(FileNotFoundException fileNotFoundException)
            {
                Debug.LogWarning(fileNotFoundException.Message);
                LoadDefault();
            }
        }

        public void LoadEmbedded()
        {
            try
            {
                Abilities = AbilityConfig.LoadEmbedded();
                Items = ItemConfig.LoadEmbedded();
                Localisation = LocalisationConfig.LoadEmbedded();
            }
            catch(FileNotFoundException fileNotFoundException)
            {
                Debug.LogWarning(fileNotFoundException.Message);
                LoadDefault();
            }
        }
    }
}