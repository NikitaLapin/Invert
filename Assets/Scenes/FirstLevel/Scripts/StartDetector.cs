using UnityEngine;

namespace Scenes.FirstLevel.Scripts
{
    public class StartDetector : MonoBehaviour
    {
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!hit.gameObject.TryGetComponent<LevelStart>(out var startComponent)) return;

            startComponent.OnRobotLevelFinished();
        }
    }
}
