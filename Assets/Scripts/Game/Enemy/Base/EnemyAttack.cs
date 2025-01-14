﻿using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public abstract class EnemyAttack : EnemyBehaviour
    {
        #region Variables

        [Header(nameof(EnemyAttack))]
        [SerializeField] private float _attackDelay = 1f;
        [SerializeField] private EnemyAnimation _animation;

        private bool _needAttack;
        private float _nextAttackTime;

        #endregion

        #region Properties

        protected EnemyAnimation Animation => _animation;
        protected Transform Target { get; private set; }

        #endregion

        #region Unity lifecycle

        protected virtual void Update()
        {
            if (!_needAttack)
            {
                return;
            }

            if (Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + _attackDelay;
                OnPerformAttack();
            }
        }

        #endregion

        #region Public methods

        public void PerformAttackForced()
        {
            OnPerformAttack();
        }

        public void StartAttack(Transform target)
        {
            Target = target;
            _needAttack = true;
        }

        public void StopAttack()
        {
            _needAttack = false;
        }

        #endregion

        #region Protected methods

        protected virtual void OnPerformAttack()
        {
            _animation.PlayAttack();
        }

        #endregion
    }
}