using System.Collections;
using TDS.Service.SceneLoading;
using CoroutineRunner = TDS.Service.Coroutine.CoroutineRunner;

namespace TDS.Infrastructure.State
{
    public class LoadGameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            SceneLoaderService sceneLoaderService = ServicesLocator.Get<SceneLoaderService>();
            sceneLoaderService.Load(SceneName.Game);

            ServicesLocator.Get<CoroutineRunner>().StartCoroutine(EnterGameWithDelay());
        }

        public override void Exit() { }

        #endregion

        #region Private methods

        private IEnumerator EnterGameWithDelay()
        {
            yield return null;
            StateMachine.Enter<GameState>();
        }

        #endregion
    }
}