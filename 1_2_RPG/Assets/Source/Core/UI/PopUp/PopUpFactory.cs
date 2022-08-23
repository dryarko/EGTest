// PopUpFactory.cs
// created by Yaroslav Nevmerzhytskyi

using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace Core.UI.PopUp
{
    internal sealed class PopUpFactory : Factory
    {
        private readonly Dictionary<Type, String> _popUpMap;

        /// <summary>
        /// PopUpFactory .ctor
        /// </summary>
        /// <param name="popUpMap">PopUp types mapped to location path</param>
        internal PopUpFactory(Dictionary<Type, String> popUpMap)
        {
            _popUpMap = popUpMap;
        }

        /// <inheritdoc />
        public override T GetInstance<T>()
        {
            return (T)GetInstance(typeof(T));
        }

        /// <inheritdoc />
        public override Object GetInstance(String name)
        {
            List<Type> types = new List<Type>(_popUpMap.Keys);
            Type type = types.Find(searchedType => searchedType.Name.Equals(name));

            return GetInstance(type);
        }

        /// <inheritdoc />
        public override Object GetInstance(Type type)
        {
            if(_popUpMap.ContainsKey(type))
            {
                return CreateInstance(_popUpMap[type]);
            }

            return null;
        }

        private Object CreateInstance(String path)
        {
            return UnityEngine.Object.Instantiate(Resources.Load(path));
        }
    }
}