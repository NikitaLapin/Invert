using MainCharacter.Movement;
using UnityEngine;

namespace Scenes.FirstLevel.Scripts
{
    public class LevelStart : MonoBehaviour
    {
        private LevelManager _levelManager;
        private PlayableLevel _level;

        private void Awake()
        {
            _levelManager = GetComponentInParent<LevelManager>();
            _level = GetComponentInParent<PlayableLevel>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent<InputLogger>(out var robotComponent)) return;

            _level.OnLevelFinished();
        }
    }
}
