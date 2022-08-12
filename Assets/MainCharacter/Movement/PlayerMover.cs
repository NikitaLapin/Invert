using UnityEngine;

namespace MainCharacter.Movement
{
    public class PlayerMover : MonoBehaviour
    {
        #region Initialization
        
        [SerializeField] private LayerMask playerMask;
        [SerializeField] private float walkSpeed = 2f;
        [SerializeField] private float jumpPower = 6.5f;
        
        private Transform _playerTransform;
        private CapsuleCollider _playerCollider;
        private Rigidbody _playerRigidBody;
        private MovementInputHandler _movementInputHandler;
        
        #endregion

        
        #region MonoBehaviourMethods

        private void Awake()
        {
            _playerTransform = GetComponent<Transform>();
            _playerRigidBody = GetComponent<Rigidbody>();
            _playerCollider = GetComponent<CapsuleCollider>();
            _movementInputHandler = GetComponent<MovementInputHandler>();
        }
        private void FixedUpdate()
        {
            _playerRigidBody.velocity = new Vector3(_movementInputHandler.CurrentInput.x * walkSpeed, _playerRigidBody.velocity.y, 0);
            
            if (!Physics.SphereCast(_playerTransform.position, 0.5f, Vector3.down, out var _,
                    _playerCollider.radius, playerMask) || !_movementInputHandler.IsJumpPressed) return;
            
            _playerRigidBody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            _movementInputHandler.IsJumpPressed = false;
        }

        #endregion
    }
}
