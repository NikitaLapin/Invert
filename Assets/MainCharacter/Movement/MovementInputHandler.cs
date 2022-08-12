using System;
using Global.MainCharacterInputSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace MainCharacter.Movement
{
    public class MovementInputHandler : MonoBehaviour
    {
        #region Initialization
        
        [SerializeField] private InputLogger inputLogger;
        [NonSerialized] public bool IsJumpPressed;
        [NonSerialized] public Vector2 CurrentInput;
        private Vector2 _moveDirection; 
        
        private MovementInput _movementInput;

        #endregion

        #region MonoBehaviourMethods

        private void Awake()
        {
            _movementInput = new MovementInput();

            _movementInput.Player.Jump.started += OnJumped;
        }

        private void Update()
        {
            _moveDirection = _movementInput.Player.Movement.ReadValue<Vector2>();
            Movement();
        }

        private void OnEnable() => _movementInput.Enable();

        private void OnDisable() => _movementInput.Disable();

        #endregion
        
        #region Events
        private void OnJumped(InputAction.CallbackContext context) => IsJumpPressed = true;

        #endregion

        #region PrivateMethods

        private void Movement()
        {
            CurrentInput = _moveDirection;
            // if (CurrentInput != Vector2.zero) inputLogger.AddLog(CurrentInput);
        }
        
        #endregion
    }
}