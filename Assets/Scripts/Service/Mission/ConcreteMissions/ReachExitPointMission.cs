using TDS.Game;
using TDS.Service.Mission.Conditions;
using UnityEngine;

namespace TDS.Service.Mission.ConcreteMissions
{
    public class ReachExitPointMission : Mission<ReachExitPointMissionCondition>
    {
        #region Protected methods

        protected override void OnBegin()
        {
            base.OnBegin();
            Condition.Observer.OnEntered += ObserverEnteredCallBack;
        }

        protected override void OnStop()
        {
            base.OnStop();
            Condition.Observer.OnEntered -= ObserverEnteredCallBack;
        }

        #endregion

        #region Private methods

        private void ObserverEnteredCallBack(Collider2D col)
        {
            if (col.CompareTag(Tag.Player))
            {
                InvokeCompletion();
            }
        }

        #endregion
    }
}