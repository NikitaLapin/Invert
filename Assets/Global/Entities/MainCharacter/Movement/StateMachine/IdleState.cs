using UnityEngine;

namespace Global.Entities.MainCharacter.Movement.StateMachine
{
    public class IdleState : State
    {
        public IdleState(CharacterMover context) : base(context){}

        private Vector3 _lastMoveVector;
        private float _stateTimer;
        
        public override void OnStateEnter()
        {
            _lastMoveVector = Context.PlayerMover.GetMove(PlayerMover.MoveType.StateMove);
            _lastMoveVector.y = 0f;
        }

        public override void OnStateUpdate()
        {
            _stateTimer += Time.fixedDeltaTime;
            var t = _stateTimer <= 1 ? _stateTimer : 1f;
            var interpolatedMoveVector = Vector3.Lerp(_lastMoveVector, Vector3.zero, t * Context.SpeedInterpolation);
            Context.PlayerMover.SetMove(PlayerMover.MoveType.StateMove, interpolatedMoveVector);
        }

        public override void OnStateExit(){}

        public override bool TrySwitchState(out State newState)
        {
            newState = null;

            if (Context.MovementInputHandler.CurrentInput.magnitude > 0f) newState = new WalkState(Context);
            else if (!Context.IsGrounded) newState = new FallState(Context);
            else if (Context.MovementInputHandler.IsJumpPressed) newState = new JumpState(Context);

            return newState != null;
        }
    }
}