// ApplicationController.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.Collections.Generic;
using System.IO;
using Core.Application;
using Core.AssetManagement;
using Core.Singleton;
using Core.UI;
using Core.UI.PopUp;
using RPG.UI.PopUps.Errors;
using RPG.UI.PopUps.Info;
using UnityEngine;

namespace RPG
{
    /// <summary>
    /// The type represents the main controller of the application. Basically, is an entry-point
    /// </summary>
    internal sealed class ApplicationController : Singleton<ApplicationController>, IApplicationFacade
    {
        public ApplicationConfig Configs { get; private set; }

        /// <inheritdoc />
        public AssetManager AssetManager
        {
            get
            {
                return null;
            }
        }

        public PopUpFactory PopUpFactory
        {
            get
            {
                return _popUpFactory;
            }
        }

        public ApplicationModel Model
        {
            get
            {
                return _model;
            }
        }

        private readonly PopUpFactory _popUpFactory;
        private readonly ApplicationModel _model;

        public ApplicationController()
        {
            Configs = new ApplicationConfig();
            Configs.Load();
            try
            {
                _model = ApplicationModel.Load();
            }
            catch(FileNotFoundException fileNotFoundException)
            {
                Debug.LogWarning(fileNotFoundException.Message);
                _model = new ApplicationModel();
                _model = _model.LoadDefault();
                _model.Save();
            }

            _popUpFactory = new PopUpFactory(GetPopUpMap());
        }

        public void Initialize()
        {
            UIManager.Instance.RegisterApplicationFacade(this);
            
            Application.targetFrameRate = 60;
        }

        private Dictionary<Type, String> GetPopUpMap()
        {
            Dictionary<Type, String> popUpMap = new Dictionary<Type, String>(); 
            
            popUpMap.Add(typeof(ErrorPopUpController), "Prefabs/PopUps/ErrorPopUpController");
            popUpMap.Add(typeof(InfoPopUpController),  "Prefabs/PopUps/InfoPopUpController");
            
            return popUpMap;
        }
    }
}