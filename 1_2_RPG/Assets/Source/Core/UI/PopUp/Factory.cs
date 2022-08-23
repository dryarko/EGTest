// Factory.cs
// created by Yaroslav Nevmerzhytskiy
// e-mail: yaroslav@elevenpillars.com
// Copyright 2018 ELEVEN PILLARS

using System;

namespace Core.UI.PopUp
{
    internal abstract class Factory
    {
        internal Factory()
        {
        }

        /// <summary>
        /// Creates the object of requested type.
        /// </summary>
        /// <typeparam name="T">type of the created object</typeparam>
        /// <returns>New instance of an object</returns>
        public abstract T GetInstance<T>()
            where T : class;

        /// <summary>
        /// Creates the object of requested type by typename.
        /// </summary>
        /// <param name="name">Name of the type(typeof(T).Name)</param>
        /// <returns>New instance of an object</returns>
        public abstract Object GetInstance(String name);

        /// <summary>
        /// Creates the object of requested type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns>New instance of an object</returns>
        public abstract Object GetInstance(Type type);
    }
}