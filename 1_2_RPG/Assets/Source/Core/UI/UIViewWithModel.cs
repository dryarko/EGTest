// UIViewWithModel.cs
// Created by Yaroslav Nevmerzhytskyi

using Core.Observer;
using Core.Observer.Impl;

namespace Core.UI
{
    internal class UIViewWithModel<TModel> : UIView, IObserver
        where TModel : Observable
    {
        public TModel Model
        {
            get
            {
                return m_model;
            }
            set
            {
                m_model = value;
                m_model.AddObserver(this);
                ApplyModel();
            }
        }

        private TModel m_model;

        internal UIViewWithModel()
        {
        }

        protected override void OnRelease()
        {
            if(m_model != null)
            {
                m_model.RemoveObserver(this);
            }

            base.OnRelease();
        }

        /// <summary>
        /// Is called only once, when the view is initialized with model
        /// </summary>
        protected virtual void ApplyModel()
        {
        }

        /// <summary>
        /// Is called every time, the model changes
        /// </summary>
        protected virtual void OnModelChanged()
        {
        }

        public void OnObjectChanged()
        {
            OnModelChanged();
        }
    }
}