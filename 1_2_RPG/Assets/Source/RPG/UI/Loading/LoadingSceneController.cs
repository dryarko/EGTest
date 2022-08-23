// LoadingSceneController.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.SceneTransition;
using Core.UI;
using UnityEngine;
using Object = System.Object;

namespace RPG.UI.Loading
{
    internal sealed class LoadingSceneController : UISceneController, ILoadingController
    {
        [SerializeField]
        private LoadingView _view;

        private LoadingModel _model;
        private AsyncOperation _unloadingOperation;
        private AsyncOperation _loadingOperation;

        internal LoadingSceneController()
        {
        }

        /// <inheritdoc />
        protected override void OnStart(params Object[] args)
        {
            base.OnStart(args);

            _model = new LoadingModel(args[0] as Type);
            _view.Model = _model;

            _unloadingOperation = UnloadOperation();

            DelayUpdate(1f);
        }

        /// <inheritdoc />
        protected override void OnDelayedUpdate()
        {
            base.OnDelayedUpdate();

            if(_unloadingOperation != null)
            {
                _model.Progress = _unloadingOperation.progress * .5f;
                if(_unloadingOperation.isDone)
                {
                    _unloadingOperation = null;
                    DelayUpdate(.05f);
                    _loadingOperation = UIManager.Instance.LoadLevel(_model.NextSceneType);
                }
            }
        }

        /// <inheritdoc />
        protected override void OnUpdate()
        {
            base.OnUpdate();

            if(_unloadingOperation != null)
            {
                _model.Progress = _unloadingOperation.progress * .5f;
                _model.SetChangedAndCommit();
            }

            if(_loadingOperation != null)
            {
                _model.Progress = (_loadingOperation.progress + 1) * 0.5f;
                _model.SetChangedAndCommit();
            }
        }

        private AsyncOperation UnloadOperation()
        {
            GC.WaitForPendingFinalizers();
            GC.Collect();

            return Resources.UnloadUnusedAssets();
        }
    }
}