using TDS.Service.Input;
using UnityEngine;

namespace TDS.Game
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        [Header("Settings")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;

        private IInputService _inputService;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            // if (Input.GetButtonDown("Fire1"))
            if (_inputService.IsAttackClicked())
            {
                Fire();
            }
        }

        #endregion

        #region Public methods

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        #endregion

        #region Private methods

        private void Fire()
        {
            _animation.TriggerAttack();
            GamePool.Spawn(_bulletPrefab, _spawnPointTransform.position, transform.rotation);
        }

        #endregion
    }
}