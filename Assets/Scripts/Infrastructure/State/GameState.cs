using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        public override void Exit()
        {
            this.Log();
        }

        public override void Enter()
        {
            
        }
    }
}