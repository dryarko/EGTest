// AssetManager.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using Core.UI.PopUp;

namespace Core.AssetManagement
{
    internal abstract class AssetManager
    {
        /// <summary>
        /// Creates a popUp of the requested type
        /// </summary>
        /// <param name="type">Type of the desired popUp</param>
        /// <returns>Object, derived from UIPopUpController</returns>
        public abstract UIPopUpController GetPopUp(Type type);
    }
}