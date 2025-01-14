﻿using System;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Game.Common
{
    [RequireComponent(typeof(Collider2D))]
    
    public class TriggerObserver : MonoBehaviour
    {
        #region Events

        public event Action<Collider2D> OnEntered;
        public event Action<Collider2D> OnExited;
        public event Action<Collider2D> OnStayed;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            this.Error($"other '{other.name}'");
            OnEntered?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnExited?.Invoke(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            OnStayed?.Invoke(other);
        }

        
        #endregion
    }
}