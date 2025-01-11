using UnityEngine.SceneManagement;

namespace TDS.Infrastructure.State
{
    public class BootstrapState : AppState
    {
        public override void Enter()
        {
            StateMachine.Enter<LoadGameState>();
        }

        public override void Exit()
        {
            
        }
    }
}