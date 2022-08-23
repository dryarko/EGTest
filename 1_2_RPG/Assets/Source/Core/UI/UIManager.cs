// UIManager.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using System.Collections.Generic;
using Core.Application;
using Core.Extensions;
using Core.SceneTransition;
using Core.UI.PopUp;
using Core.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;
using AsyncOperation = UnityEngine.AsyncOperation;

namespace Core.UI
{
    internal sealed class UIManager : UnitySingleton<UIManager>
    {
        private static readonly Int32 InitialCollectionSize = 5;

        public event Action SceneLoaded;

        public UISceneController SceneController
        {
            get
            {
                return _currentSceneController;
            }
        }

        private Stack<Object[]> _args;
        private Dictionary<Guid, Object[]> _commandArgs;
        private List<UIController> _controllers;
        private UISceneController _currentSceneController;
        private Stack<UIPopUpController> _popUps;

        private IApplicationFacade _applicationFacade;

        internal UIManager()
        {
            _args = new Stack<Object[]>(InitialCollectionSize);
            _commandArgs = new Dictionary<Guid, Object[]>(InitialCollectionSize);
            _controllers = new List<UIController>(InitialCollectionSize);
            _popUps = new Stack<UIPopUpController>(InitialCollectionSize);
        }

        protected override void OnRelease()
        {
            _args.Clear();
            _args = null;
            _commandArgs.Clear();
            _commandArgs = null;
            _controllers.Clear();
            _controllers = null;
            _popUps.Clear();
            _popUps = null;

            base.OnRelease();
        }

        public void RegisterApplicationFacade(IApplicationFacade applicationFacade)
        {
            _applicationFacade = applicationFacade;
        }

        public void RegisterController(UIController controller)
        {
            if(!_controllers.Contains(controller))
            {
                _controllers.Add(controller);
            }

            if(controller is UISceneController)
            {
                _currentSceneController = (UISceneController)controller;
                if(SceneLoaded != null)
                {
                    SceneLoaded();
                }
            }
        }

        /// <summary>
        /// Poll arguments
        /// </summary>
        public Object[] GetArgs()
        {
            if(_args != null)
            {
                if(_args.Count > 0)
                {
                    return _args.Pop();
                }
            }

            return null;
        }

        /// <summary>
        /// Poll arguments used by Commands
        /// </summary>
        public Object[] GetCommandArgs(Guid commandId)
        {
            if(_commandArgs != null)
            {
                if(_commandArgs.Count > 0 && _commandArgs.ContainsKey(commandId))
                {
                    return _commandArgs[commandId];
                }
            }

            return null;
        }

        /// <summary>
        /// Push arguments used by Commands
        /// </summary>
        public void PushCommandArgs(Guid commandId, params Object[] args)
        {
            if(args != null && _commandArgs != null)
            {
                if(args.Length > 0)
                {
                    _commandArgs[commandId] = args;
                }
            }
        }

        public void UnregisterController(UIController controller)
        {
            if(_controllers.Contains(controller))
            {
                _controllers.Remove(controller);
            }
        }

        public void UnregisterAllControllers(UIController controller)
        {
            _controllers.Clear();
        }

        /// <summary>
        /// Load scene, stored in the UISceneController's SneneName attribute.
        /// </summary>
        /// <param name="args">initializing arguments, that can be obtained in OnStart(arg) method of UISceneController</param>
        public AsyncOperation LoadLevel<TController>(params Object[] args)
        {
            return LoadLevel(typeof(TController), args);
        }

        public AsyncOperation LoadLevel(Type type, params Object[] args)
        {
            SceneNameAttribute sceneNameAttr = type.GetFirstAttribute<SceneNameAttribute>();
            if(args != null && args.Length > 0)
            {
                _args.Push(args);
            }

            if(_currentSceneController is ILoadingController)
            {
                return SceneManager.LoadSceneAsync(sceneNameAttr.Name);
            }
            else
            {
                _args.Push(new Object[] {type});

                String loadingSceneName = typeof(ILoadingController).GetFirstAttribute<SceneNameAttribute>().Name;

                return SceneManager.LoadSceneAsync(loadingSceneName);
            }
        }

        public TPopUpController OpenPopUp<TPopUpController>(params Object[] args)
            where TPopUpController : UIPopUpController
        {
            return (TPopUpController)OpenPopUp(typeof(TPopUpController), args);
        }

        public UIPopUpController OpenPopUp(Type type, params Object[] args)
        {
            if(args != null)
            {
                if(args.Length > 0)
                {
                    _args.Push(args);
                }
            }

            GameObject popUpObject = (GameObject)_applicationFacade.PopUpFactory.GetInstance(type);
            UIPopUpController popUp = popUpObject.GetComponent<UIPopUpController>();

            _popUps.Push(popUp);

            return popUp;
        }

        public void ClosePopUp()
        {
            UIPopUpController popUp = _popUps.Pop();
            Destroy(popUp.gameObject);
        }
    }
}