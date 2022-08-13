using System.Collections.Generic;
using MainCharacter.Movement;
using UnityEngine;

namespace Scenes.FirstLevel.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<PlayableLevel> levels;
        
        [SerializeField] private MovementInputHandler mainCharacter;
        [SerializeField] private InputLogger robot;

        private void OnEnable()
        {
            ActivateCurrentLevel();
        }

        public void ActivateCurrentLevel()
        {
            if(!PlayerPrefs.HasKey("Current Level")) PlayerPrefs.SetInt("Current Level", 1);
            
            var currentLevel = levels[PlayerPrefs.GetInt("Current Level") - 1];
            currentLevel.Activate(mainCharacter.transform, robot.transform);
        }
    }
}
