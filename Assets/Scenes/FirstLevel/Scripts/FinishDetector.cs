using UnityEngine;

namespace Scenes.FirstLevel.Scripts
{
    public class FinishDetector : MonoBehaviour
    {
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!hit.gameObject.TryGetComponent<LevelFinish>(out var finishComponent)) return;

            finishComponent.OnCharacterLevelFinished();
        }
    }
}
