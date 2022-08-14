using UnityEngine;

namespace Global.Entities.Robot.Movement
{
    public class RobotMover : MonoBehaviour
    {
        #region Initialization

        public Vector3 DeltaMove { get; private set; }
        private InputLogger _inputLogger;
        private CharacterController _controller;

        #endregion

        #region SubStateMethods

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _inputLogger = GetComponent<InputLogger>();
        }

        private void FixedUpdate()
        {
            DeltaMove = _inputLogger.GetFirstLog();
            _inputLogger.DeleteFirstLog();

            _controller.Move(DeltaMove * Time.fixedDeltaTime);
        }

        #endregion
    }
    
    public class BotStateMove
    {
        public BotStateMove(Vector3 move, BotMoveType moveType)
        {
            Move = move;
            MoveType = moveType;
        }
            
        public Vector3 Move;
        public BotMoveType MoveType;
    }

    public enum BotMoveType
    {
        StateMove, GravityMove
    }
}