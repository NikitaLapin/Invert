using UnityEngine;

namespace Scenes.FirstLevel.Scripts
{
    public class PlayableLevel : MonoBehaviour
    {
        public int id;
        public Transform levelCameraPosition;
        public Transform startPosition;
        public Transform endPosition;

        public void Activate(Transform mainCharacterTransform, Transform robotTransform)
        {
            mainCharacterTransform.GetComponent<CharacterController>().enabled = false;
            mainCharacterTransform.position = startPosition.position;
            mainCharacterTransform.GetComponent<CharacterController>().enabled = true;
            
            robotTransform.GetComponent<CharacterController>().enabled = false;
            robotTransform.position = endPosition.position;
            robotTransform.GetComponent<CharacterController>().enabled = true;
            
            if (Camera.main != null) Camera.main.transform.position = levelCameraPosition.position;
        }

        public void OnLevelFinished()
        {
            
        }
    }
}
