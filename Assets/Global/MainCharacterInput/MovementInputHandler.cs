using System;
using System.Numerics;
using Global.Input.Scripts;
using UnityEngine.InputSystem;

namespace Global.MainCharacterInput
{
    public class MovementInputHandler : InputHandler
    {
        #region Initialization

        [NonSerialized] public Vector2 CurrentInput;
        [NonSerialized] public Vector2 LastInput;
        [NonSerialized] public bool IsJumpPressed;

        private MovementInput _movementInput;
        private InputActionMap _lastActionMap;

        #endregion

        #region MonoBehaviourMethods

        private void Awake()
        {
            _movementInput = new MovementInput();
            _lastActionMap = _movementInput.MainCharacterInput;
        }

        public void OnEnable()
        {
            _movementInput.Enable();
            _lastActionMap.Enable();
                
            //MainCharacter Handlers
            _movementInput.MainCharacterInput.Walk.started += OnWalkChanged;
            _movementInput.MainCharacterInput.Walk.performed += OnWalkChanged;
            _movementInput.MainCharacterInput.Walk.canceled += OnWalkChanged;

            _movementInput.MainCharacterInput.Jump.started += OnJumpChanged;
            _movementInput.MainCharacterInput.Jump.canceled += OnJumpChanged;
        }

        public void OnDisable()
        {
            CurrentInput = Vector2.Zero;
            IsJumpPressed = false;
            _movementInput.Disable();
        }
        
        #endregion

        #region EventHandlers

        private void OnWalkChanged(InputAction.CallbackContext context) => AddInputLog(context.ReadValue<Vector2>());
        private void OnJumpChanged(InputAction.CallbackContext context) => IsJumpPressed = context.ReadValueAsButton();

        #endregion

        #region PublicMethods

        public void MainCharacterInputEnable()
        {
            _movementInput.MainCharacterInput.Enable();
            _lastActionMap = _movementInput.MainCharacterInput;
        }

        public override void Disable() => OnDisable();

        public override void Enable() => OnEnable();

        #endregion

        #region PrivateMethods

        private void AddInputLog(Vector2 newInput)
        {
            LastInput = CurrentInput;
            CurrentInput = newInput;
        }

        #endregion
    }
}