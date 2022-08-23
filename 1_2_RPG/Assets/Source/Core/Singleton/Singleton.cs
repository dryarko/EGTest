// Singleton.cs
// created by Yaroslav Nevmerzhytskyi

namespace Core.Singleton
{
    internal class Singleton<T>
        where T : Singleton<T>, new()
    {
        public static T Instance
        {
            get
            {
                return _instance ?? (_instance = new T());
            }
        }

        private static T _instance;

        protected Singleton()
        {
        }
    }
}