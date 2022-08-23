// UnitySingleton.cs
// Created by Yaroslav Nevmerzhytskyi

using UnityEngine;

namespace Core.Unity
{
    internal class UnitySingleton<T> : UnityBehaviour
        where T : UnitySingleton<T>
    {
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<T>();
                }

                return _instance;
            }
        }

        private static T _instance;

        protected UnitySingleton()
        {
        }
    }
}