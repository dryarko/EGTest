using System;
using Core.Domain;

namespace Core.Observer
{
    public interface IObservable : IDomainObject
    {
        Boolean IsDirty { get; }

        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void RemoveAllObservers();

        /// <summary>
        /// Method triggers notification to all Observers, about the change of Observable
        /// </summary>
        void SetChangedAndCommit();
        void SetChanged();
        void Commit();
    }
}