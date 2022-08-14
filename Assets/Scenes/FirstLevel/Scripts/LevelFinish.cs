using UnityEngine;

namespace Scenes.FirstLevel.Scripts
{
    public class LevelFinish : MonoBehaviour
    {
        private PlayableLevel _level;

        private void Awake()
        {
            _level = GetComponentInParent<PlayableLevel>();
        }

        public void OnCharacterLevelFinished() => _level.CharacterLevelFinished();
    }
}
