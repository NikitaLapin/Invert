using UnityEngine;

namespace Global.Entities.MainCharacter.Movement.StateMachine
{
    public class FallState : State
    {
        public FallState(CharacterMover context) : base(context){}

        public override void OnStateEnter(){}

        public override void OnStateUpdate()
        {
            var lastMoveJump = Context.PlayerMover.GetMove(PlayerMover.MoveType.StateMove).y;
            var moveVector = new Vector3(Context.MovementInputHandler.CurrentInput.x * Context.WalkSpeed, lastMoveJump, 0f);
            Context.PlayerMover.SetMove(PlayerMover.MoveType.StateMove, moveVector);
        }

        public override void OnStateExit() => Context.PlayerMover.SetMove(PlayerMover.MoveType.StateMove, Vector3.zero);

        public override bool TrySwitchState(out State newState)
        {
            newState = null;

            if (Context.IsGrounded) newState = new IdleState(Context);

            return newState != null;
        }
    }
}