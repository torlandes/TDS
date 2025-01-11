using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        public override void Exit()
        {
            Debug.Log("GameState Enter");
        }

        public override void Enter()
        {
            
        }
    }
}