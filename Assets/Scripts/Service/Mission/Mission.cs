﻿using System;

namespace TDS.Service.Mission
{
    public abstract class Mission
    {
        #region Events

        public event Action OnCompleted;

        #endregion

        #region Public methods

        public void Begin()
        {
            OnBegin();
        }

        public void Stop()
        {
            OnStop();
        }

        public void Update()
        {
            OnUpdate();
        }

        #endregion

        #region Protected methods

        protected void InvokeCompletion()
        {
            OnCompleted?.Invoke();
        }

        protected virtual void OnBegin() { }

        protected virtual void OnStop() { }

        protected virtual void OnUpdate() { }

        #endregion
    }

    public abstract class Mission<TCondition> : Mission where TCondition : MissionCondition
    {
        #region Properties

        protected TCondition Condition { get; private set; }

        #endregion

        #region Public methods

        public void SetCondition(TCondition condition)
        {
            Condition = condition;
        }

        #endregion
    }
}