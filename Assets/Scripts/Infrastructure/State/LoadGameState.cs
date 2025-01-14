﻿using TDS.Infrastructure.Locator;
using TDS.Service.SceneLoading;

namespace TDS.Infrastructure.State
{
    public class LoadGameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            SceneLoaderService sceneLoaderService = ServicesLocator.Instance.Get<SceneLoaderService>();
            sceneLoaderService.Load(SceneName.Game);

            StateMachine.Enter<GameState>();
        }

        public override void Exit() { }

        #endregion
    }
}