using TDS.Infrastructure.Locator;
using TDS.Service.Coroutine;
using TDS.Service.SceneLoading;
using TDS.Utils.Log;
using UnityEngine.SceneManagement;

namespace TDS.Infrastructure.State
{
    public class BootstrapState : AppState
    {
        public override void Enter()
        {
            this.Log();
            
            ServicesLocator.Register(new SceneLoaderService());
            ServicesLocator.RegisterMono<CoroutineRunner>();
            
            StateMachine.Enter<LoadGameState>();
        }

        public override void Exit()
        {
            
        }
    }
}