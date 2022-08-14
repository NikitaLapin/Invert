using System;
using Global.Entities.MainCharacter.Movement;
using UnityEngine;

namespace Scenes.FirstLevel.Scripts
{
    public class FinishDetector : MonoBehaviour
    {
        [SerializeField] private GameObject robot;
        private MovementInputHandler _movementInputHandler;
        private GameObject _mainCharacter;

        private void Awake()
        {
            _movementInputHandler = GetComponent<MovementInputHandler>();
            _mainCharacter = _movementInputHandler.gameObject;
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!hit.gameObject.TryGetComponent<LevelFinish>(out var finishComponent)) return;

            finishComponent.OnCharacterLevelFinished(_mainCharacter, robot);
        }
    }
}
