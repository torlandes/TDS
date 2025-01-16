using System;
using TDS.Infrastructure.Locator;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Service.Mission
{
    public class MissionService : MonoBehaviour, IService
    {
        #region Variables

        private Mission _currentMission;

        private readonly MissionFactory _factory = new();

        private event Action OnStarted;
        private event Action OnCompleted;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            _currentMission?.Update();
        }

        #endregion

        #region Public methods

        public void Dispose()
        {
            if (_currentMission != null)
            {
                _currentMission.OnCompleted -= MissionCompletedCallback;
                _currentMission.Stop();
            }

            _currentMission = null;
        }

        public void Initialize()
        {
            MissionConditionHolder holder = FindObjectOfType<MissionConditionHolder>();
            _currentMission.OnCompleted += MissionCompletedCallback;
            _currentMission.Begin();
            OnStarted?.Invoke();
        }

        #endregion

        #region Private methods

        private void MissionCompletedCallback()
        {
            this.Error();
            OnCompleted?.Invoke();
        }

        #endregion
    }
}