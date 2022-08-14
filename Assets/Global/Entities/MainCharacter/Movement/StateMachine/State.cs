namespace Global.Entities.MainCharacter.Movement.StateMachine
{
    public abstract class State
    {
        protected CharacterMover Context;
        
        public State(CharacterMover context) => Context = context;
        public abstract void OnStateEnter();
        public abstract void OnStateUpdate();
        public abstract void OnStateExit();
        public abstract bool TrySwitchState(out State newState);
    }
}