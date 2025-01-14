﻿using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class RangeEnemyAttack : EnemyAttack
    {
        #region Variables

        [Header(nameof(RangeEnemyAttack))]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;

        private float _timer;

        #endregion

        #region Unity lifecycle

        protected override void Update()
        {
            base.Update();

            if (Target == null)
            {
                return;
            }

            Rotate();
        }

        #endregion

        #region Protected methods

        protected override void OnPerformAttack()
        {
            base.OnPerformAttack();
            
            Instantiate(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        #endregion

        #region Private methods

        private void Rotate()
        {
            transform.up = Target.position - transform.position;
        }

        #endregion
    }
}