using UnityEngine;

namespace Global.Entities.Robot.Movement
{
    public class BotMover : MonoBehaviour
    {
        #region Initialization

        public bool IsGrounded { get; private set; }
        
        [SerializeField] private LayerMask botMask;
        [SerializeField] private float walkSpeed = 5f;
        [SerializeField] private float jumpStrength;
        [SerializeField] private float highJumpStrength;
        [SerializeField] private float speedInterpolation = 6f;
        
        public Transform BotTransform { get; private set; }
        public CharacterController CharacterController { get; private set; }
        public RobotMover RobotMover { get; private set; }
        
        public LayerMask BotMask => botMask;
        public float WalkSpeed => walkSpeed;
        public float JumpStrength => jumpStrength;
        public float HighJumpStrength => highJumpStrength;
        public float SpeedInterpolation => speedInterpolation;
        
        private float _originalSlopeLimit;

        #endregion

        #region MonoBehaviourMethods

        private void Awake()
        {
            BotTransform = GetComponent<Transform>();
            RobotMover = GetComponent<RobotMover>();
            CharacterController = GetComponent<CharacterController>();
        }

        private void Start() => _originalSlopeLimit = CharacterController.slopeLimit;

        private void FixedUpdate()
        {
            var lossyScale = CharacterController.transform.lossyScale;
            var height = CharacterController.height * lossyScale.y;
            var radius = CharacterController.radius * lossyScale.x;
            var center = CharacterController.center + BotTransform.position;

            IsGrounded = Physics.SphereCast(center, radius, Vector3.down, out _, height / 2 - radius + 0.1f, botMask);

            CharacterController.slopeLimit = IsGrounded ? _originalSlopeLimit : 45f;
        }

        #endregion
    }
}