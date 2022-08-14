using System;
using Global.Entities.Robot.Movement;
using Global.MainCharacterInputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Global.Entities.MainCharacter.Movement
{
    public class MovementInputHandler : MonoBehaviour
    {
        #region Initialization
        
        [NonSerialized] public bool IsJumpPressed;
        [NonSerialized] public Vector2 CurrentInput;
        
        [SerializeField] private InputLogger inputLogger;
        
        private CharacterMover _characterMover;
        private MovementInput _movementInput;

        private Vector2 _moveDirection; // TO DELETE

        #endregion

        #region MonoBehaviourMethods

        private void Awake()
        {
            _movementInput = new MovementInput();
            _characterMover = GetComponent<CharacterMover>();
            inputLogger = gameObject.AddComponent<InputLogger>();
        }

        private void Update() // TO DELETE
        {
            _moveDirection = _movementInput.Player.Movement.ReadValue<Vector2>();
            Movement();
        }

        private void OnEnable()
        {
            _movementInput.Enable();
            
            _movementInput.Player.Jump.started += OnJumped;
            _movementInput.Player.Jump.canceled += OnJumped;

            _movementInput.Player.Movement.started += OnMovement;
            _movementInput.Player.Movement.performed += OnMovement;
            _movementInput.Player.Movement.canceled += OnMovement;
        }

        private void OnDisable()
        {
            _movementInput.Disable();
            
            _movementInput.Player.Jump.started -= OnJumped;
            _movementInput.Player.Jump.canceled -= OnJumped;
            
            _movementInput.Player.Movement.started -= OnMovement;
            _movementInput.Player.Movement.performed -= OnMovement;
            _movementInput.Player.Movement.canceled -= OnMovement;
        }

        #endregion
        
        #region Events

        private void OnJumped(InputAction.CallbackContext context) => IsJumpPressed = context.ReadValueAsButton();

        private void OnMovement(InputAction.CallbackContext context){}

        #endregion

        #region PrivateMethods

        private void Movement() => CurrentInput = _moveDirection; // TO DELETE

        #endregion
    }
}