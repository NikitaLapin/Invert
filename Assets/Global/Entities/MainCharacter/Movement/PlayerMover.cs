using System.Collections.Generic;
using UnityEngine;

namespace Global.Entities.MainCharacter.Movement
{
    public class PlayerMover : MonoBehaviour
    {
        public Vector3 DeltaMove { get; private set; }
        private List<StateMove> _movesList = new();
        private CharacterController _controller;

        private void Awake() => _controller = GetComponent<CharacterController>();

        private void FixedUpdate()
        {
            DeltaMove = Vector3.zero;
            foreach (var move in _movesList) DeltaMove += move.Move;

            _controller.Move(DeltaMove * Time.fixedDeltaTime);
        }

        public Vector3 GetMove(MoveType moveType)
        {
            foreach(var move in _movesList)
                if (move.MoveType == moveType) return move.Move;
            
            return Vector3.zero;
        }

        public void SetMove(MoveType moveType, Vector3 move)
        {
            foreach(var thisMove in _movesList)
            {
                if (thisMove.MoveType == moveType)
                {
                    thisMove.Move = move;
                    return;
                }
            }
            
            _movesList.Add(new StateMove(move, moveType));
        }
        
        public class StateMove
        {
            public StateMove(Vector3 move, MoveType moveType)
            {
                Move = move;
                MoveType = moveType;
            }
            
            public Vector3 Move;
            public MoveType MoveType;
        }

        public enum MoveType
        {
            StateMove, GravityMove
        }
    }
}
