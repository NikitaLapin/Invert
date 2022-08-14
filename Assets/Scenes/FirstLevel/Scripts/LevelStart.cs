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
        
        public void OnRobotLevelFinished() => _level.RobotLevelFinished();
    }
}
