using Global.Entities.MainCharacter.Movement;
using UnityEngine;

namespace Scenes.FirstLevel.Scripts
{
    public class StartDetector : MonoBehaviour
    {
        [SerializeField] private GameObject mainCharacter;
        [SerializeField] private GameObject robot; // NEED TO REMAKE!!!
        private MovementInputHandler _movementInputHandler;

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!hit.gameObject.TryGetComponent<LevelStart>(out var startComponent)) return;

            startComponent.OnRobotLevelFinished(robot, mainCharacter);
        }
    }
}
