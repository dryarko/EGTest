// LoadingModel.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using Core.Observer.Impl;

namespace RPG.UI.Loading
{
    internal sealed class LoadingModel : Observable
    {
        public readonly Type NextSceneType;
        public Single Progress;

        internal LoadingModel(Type nextSceneType)
        {
            NextSceneType = nextSceneType;
        }
    }
}