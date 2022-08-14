using UnityEngine;

namespace Global.Entities.MainCharacter.Movement.StateMachine
{
    public class WalkState : State
    {
        public WalkState(CharacterMover context) : base(context) {}
        
        public override void OnStateEnter(){}

        public override void OnStateUpdate()
        {
            var input = Context.MovementInputHandler.CurrentInput;
            var direction = new Vector3(input.x, 0f, 0f);
            
            Context.PlayerMover.SetMove(PlayerMover.MoveType.StateMove, direction * Context.WalkSpeed);
        }

        public override void OnStateExit(){}

        public override bool TrySwitchState(out State newState)
        {
            newState = null;

            if (Context.MovementInputHandler.CurrentInput.magnitude == 0f) newState = new IdleState(Context);
            else if (!Context.IsGrounded) newState = new FallState(Context);
            else if (Context.MovementInputHandler.IsJumpPressed) newState = new JumpState(Context);

            return newState != null;
        }
    }
}