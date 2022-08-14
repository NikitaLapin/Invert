using Global.Entities.MainCharacter.Movement.StateMachine;
using MainCharacter.Movement;
using UnityEngine;

namespace Global.Entities.MainCharacter.Movement
{
    public class CharacterMover : MonoBehaviour
    {
        #region Initialization

        public bool IsGrounded { get; private set; }
        
        [SerializeField] private LayerMask playerMask;
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float jumpStrength;
        [SerializeField] private float highJumpStrength;
        [SerializeField] private float speedInterpolation = 6f;

        public Transform PlayerTransform { get; private set; }
        public CharacterController CharacterController { get; private set; }
        public MovementInputHandler MovementInputHandler { get; private set; }
        public PlayerMover PlayerMover { get; private set; }

        public LayerMask PlayerMask => playerMask;
        public float WalkSpeed => walkSpeed;
        public float JumpStrength => jumpStrength;
        public float HighJumpStrength => highJumpStrength;
        public float SpeedInterpolation => speedInterpolation;

        private State _currentState;
        private float _originalSlopeLimit;

        #endregion

        #region MonoBehaviourMethods

        private void Awake()
        {
            PlayerTransform = GetComponent<Transform>();
            MovementInputHandler = GetComponent<MovementInputHandler>();
            PlayerMover = GetComponent<PlayerMover>();
            CharacterController = GetComponent<CharacterController>();
        }

        private void Start()
        {
            _currentState = new IdleState(this);
            _currentState.OnStateEnter();

            _originalSlopeLimit = CharacterController.slopeLimit;
        }

        private void FixedUpdate()
        {
            var lossyScale = CharacterController.transform.lossyScale;
            var height = CharacterController.height * lossyScale.y;
            var radius = CharacterController.radius * lossyScale.x;
            var center = CharacterController.center + PlayerTransform.position;

            IsGrounded = Physics.SphereCast(center, radius, Vector3.down, out _, height/2 - radius + 0.1f, playerMask);
            
            CharacterController.slopeLimit = IsGrounded ? _originalSlopeLimit : 45f;
            
            if (_currentState.TrySwitchState(out var newState))
            {
                _currentState.OnStateExit();
                _currentState = newState;
                _currentState.OnStateEnter();
                return;
            }

            _currentState.OnStateUpdate();
        }

        #endregion
    }
}