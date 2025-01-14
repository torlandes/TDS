﻿using System;
using UnityEngine;

namespace TDS.Game.Common
{
    public class UnitHp : MonoBehaviour, IDamageable
    {
        #region Variables

        [SerializeField] private int _start = 10;
        [SerializeField] private int _max = 10;
        [SerializeField] private int _current;

        #endregion

        #region Events

        public event Action<int> OnChanged;

        #endregion

        #region Properties

        public int Current => _current;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _current = _start;
        }

        #endregion

        #region Public methods

        public void ApplyDamage(int damage)
        {
            Change(-damage);
        }

        public void Change(int value)
        {
            int newValue = Mathf.Clamp(_current + value, 0, _max);
            bool needNotify = newValue != _current;
            _current = newValue;

            if (needNotify)
            {
                OnChanged?.Invoke(_current);
            }
        }

        #endregion
    }
}