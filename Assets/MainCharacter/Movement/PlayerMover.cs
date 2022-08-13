using System;
using UnityEngine;

namespace MainCharacter.Movement
{
    public class PlayerMover : MonoBehaviour
    {
        #region Initialization
        
        [SerializeField] private LayerMask playerMask;
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float jumpPower = 12.5f;
        
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

            var playerLossyScale = _playerTransform.lossyScale;
            var playerRadius = _playerCollider.radius * playerLossyScale.x;
            var playerHeight = _playerCollider.height * playerLossyScale.y;
            
            if (!Physics.SphereCast(_playerTransform.position + _playerCollider.center, playerRadius, Vector3.down, out var hit,
                    playerHeight / 2 - playerRadius + 0.01f, playerMask) || !_movementInputHandler.IsJumpPressed) return;
            
            _playerRigidBody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            _movementInputHandler.IsJumpPressed = false;
        }

        #endregion
    }
}
