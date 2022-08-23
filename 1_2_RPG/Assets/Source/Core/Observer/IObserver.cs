// IObserver.cs
// Created by Yaroslav Nevmerzhytskyi

namespace Core.Observer
{
    /// <summary>
    /// Has to be implemented to subscribe to changes on the Observable
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Method, which is called by Observable, when it is changed
        /// </summary>
        void OnObjectChanged();
    }
}