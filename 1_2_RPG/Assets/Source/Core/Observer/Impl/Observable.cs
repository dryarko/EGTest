// Observable.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using System.Collections.Generic;
using Core.Domain.Impl;

namespace Core.Observer.Impl
{
    public class Observable : DomainObject, IObservable
    {
        public Boolean IsDirty
        {
            get
            {
                return _isDirty;
            }
        }

        private readonly List<IObserver> _observers;
        private Boolean _isDirty;

        public Observable()
        {
            _observers = new List<IObserver>();
            _isDirty = false;
        }

        public void AddObserver(IObserver observer)
        {
            if(!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            if(_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void RemoveAllObservers()
        {
            _observers.Clear();
        }

        public void SetChangedAndCommit()
        {
            SetChanged();
            Commit();
        }

        public void SetChanged()
        {
            _isDirty = true;
        }

        public void Commit()
        {
            if(_isDirty)
            {
                for(Int32 observerIndex = 0; observerIndex < _observers.Count; ++observerIndex)
                {
                    _observers[observerIndex].OnObjectChanged();
                }

                _isDirty = false;
            }
        }
    }
}