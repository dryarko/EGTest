// StartUpSceneController.cs
// Created by Yaroslav Nevmerzhytskyi

using Core.SceneTransition;
using Core.UI;
using RPG.UI.Menu;
using UnityEngine;

namespace RPG.UI.Splash
{
    [SceneName("StartUp")]
    internal sealed class StartUpSceneController : UISceneController
    {
        [SerializeField]
        private StartUpView _view;
        
        internal StartUpSceneController()
        {
        }

        /// <inheritdoc />
        protected override void OnStart()
        {
            base.OnStart();

            ApplicationController.Instance.Initialize();

            UIManager.Instance.LoadLevel<MenuSceneController>();
        }
    }
}