using UnityEngine;

namespace Global.Entities.MainCharacter.Movement.StateMachine
{
    public class JumpState : State
    {
        public JumpState(CharacterMover context) : base(context){}
        
        private Vector3 _lastMoveVector;
        private Vector2 _lastInput;
        private float _stateTimer;

        private bool _isJumpPressed;
        private float _currentJumpStrength;

        public override void OnStateEnter()
        {
            _lastMoveVector = Context.PlayerMover.GetMove(PlayerMover.MoveType.StateMove);
            _lastMoveVector.y = 0f;
            var jumpMoveVector = _lastMoveVector + Vector3.up * Context.JumpStrength;
            Context.PlayerMover.SetMove(PlayerMover.MoveType.StateMove, jumpMoveVector);

            _isJumpPressed = true;
            _currentJumpStrength = Context.JumpStrength;
            _lastInput = Context.MovementInputHandler.CurrentInput;
        }

        public override void OnStateUpdate()
        {
            _stateTimer += Time.fixedDeltaTime;
            if (!Context.MovementInputHandler.IsJumpPressed) _isJumpPressed = false;

            var moveVector = new Vector3(Context.MovementInputHandler.CurrentInput.x * Context.WalkSpeed, _currentJumpStrength, 0f);
            Context.PlayerMover.SetMove(PlayerMover.MoveType.StateMove, moveVector);

            if(_stateTimer < 0.1f || !_isJumpPressed) return;
            
            _lastMoveVector.y = 0f;
            var jumpMoveVector = _lastMoveVector + Vector3.up * Context.HighJumpStrength;
            Context.PlayerMover.SetMove(PlayerMover.MoveType.StateMove, jumpMoveVector);
            _currentJumpStrength = Context.HighJumpStrength;
        }

        public override void OnStateExit(){}

        public override bool TrySwitchState(out State newState)
        {
            newState = null;

            if (Context.IsGrounded) newState = new IdleState(Context);
            else if (Context.PlayerMover.DeltaMove.y < 0) newState = new FallState(Context);

            return newState != null;
        }
    }
}