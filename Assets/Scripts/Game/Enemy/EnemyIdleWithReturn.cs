﻿using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyIdleWithReturn : EnemyIdle
    {
        #region Variables

        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private float _stopDistance = 0.3f;

        private Transform _startPoint;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _startPoint = new GameObject($"Start Point {gameObject.name}").transform;
            _startPoint.position = transform.position;
        }

        private void Update()
        {
            if (Vector3.Distance(_startPoint.position, transform.position) <= 0.3f)
            {
                _movement.SetTarget(null);
            }
        }

        private void OnEnable()
        {
            _movement.SetTarget(_startPoint);
            _movement.Activate();
        }

        #endregion
    }
}