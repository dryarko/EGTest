// SceneNameAttribute.cs
// Created by Yaroslav Nevmerzhytskyi

using System;

namespace Core.SceneTransition
{
    /// <summary>
    /// An attribute, that stores the name of the scene. Should be applied to UISceneControllers.
    /// </summary>
    internal sealed class SceneNameAttribute : Attribute
    {
        public readonly String Name;

        internal SceneNameAttribute(String name)
        {
            Name = name;
        }
    }
}