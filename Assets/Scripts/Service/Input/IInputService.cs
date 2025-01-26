using TDS.Infrastructure.Locator;
using UnityEngine;

namespace TDS.Service.Input
{
    public interface IInputService : IService
    {
        #region Properties

        Vector3 LookDirection { get; }
        Vector2 MoveDirection { get; }

        #endregion

        #region Public methods

        bool IsAttackClicked();

        #endregion
    }
}