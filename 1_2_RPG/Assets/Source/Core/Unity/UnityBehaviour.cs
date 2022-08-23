// UnityBehaviour.cs
// Created by Yaroslav Nevmerzhytskyi

using System;
using UnityEngine;
using UnityTime = UnityEngine.Time;

namespace Core.Unity
{
    internal class UnityBehaviour : MonoBehaviour
    {
        public Transform Transform
        {
            get
            {
                return _transform;
            }
        }

        private Transform _transform;
        private Single _timer;
        private Single _delay;
        private Boolean _isLoop;
        private Boolean _isDelayed;

        internal UnityBehaviour()
        {
        }

        /// <summary>
        /// Allows to delay invocation of the method. <b>The method will be executed at least once.</b>
        /// Invocation can be looped. <b>Delay is frame-length-dependant</b>
        /// </summary>
        /// <param name="delay">desired delay</param>
        /// <param name="isLoop">marks if method should be looped</param>
        protected void DelayUpdate(Single delay, Boolean isLoop = true)
        {
            _timer = 0f;
            _delay = delay;
            _isDelayed = true;
            _isLoop = isLoop;
        }

        protected void StopDelayedUpdate()
        {
            _timer = 0f;
            _delay = 0f;
            _isDelayed = false;
            _isLoop = false;
        }

        protected virtual void OnAwake()
        {
        }

        protected virtual void OnStart()
        {
        }

        protected virtual void OnRelease()
        {
        }

        protected virtual void OnUpdate()
        {
        }

        protected virtual void OnFixedUpdate()
        {
        }

        protected virtual void OnLateUpdate()
        {
        }

        protected virtual void OnDelayedUpdate()
        {
        }

        private void Awake()
        {
            _transform = transform;
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        private void OnDestroy()
        {
            OnRelease();
        }

        private void Update()
        {
            OnUpdate();
            if(_isDelayed)
            {
                if(_timer >= _delay)
                {
                    OnDelayedUpdate();

                    _timer = 0f;
                    if(!_isLoop)
                    {
                        _isDelayed = false;
                    }
                }

                _timer += UnityTime.deltaTime;
            }
        }

        private void FixedUpdate()
        {
            OnFixedUpdate();
        }

        private void LateUpdate()
        {
            OnLateUpdate();
        }
    }
}