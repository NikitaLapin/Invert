using UnityEngine;

namespace Scenes.FirstLevel.Scripts
{
    public class LevelStart : MonoBehaviour
    {
        private PlayableLevel _level;

        private void Awake()
        {
            _level = GetComponentInParent<PlayableLevel>();
        }
        
        public void OnRobotLevelFinished(GameObject robot, GameObject mainCharacter) => _level.RobotLevelFinished(robot, mainCharacter);
    }
}
