using System.Collections.Generic;
using UnityEngine;

namespace LoadScreen.Scripts
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private InteractiveTrigger trigger;
        [SerializeField] private List<EnableObject> objectsToEnable;
        [SerializeField] private GameObject[] menu;

        private void OnEnable()
        {
            trigger.Triggered += SwitchTrigger;
            trigger.Clicked += SwitchMenu;
        }
        private void OnDisable()
        {
            trigger.Triggered -= SwitchTrigger;
            trigger.Clicked -= SwitchMenu;
        }

        private void SwitchTrigger(bool isActive)
        {
            foreach (var element in objectsToEnable) element.Switch(isActive);
        }

        private void SwitchMenu()
        {
            foreach (var component in menu) component.SetActive(true);
        }
        
        
        [System.Serializable]
        public struct EnableObject
        {
            [SerializeField] private InteractApplier objectToSwitch;
            [SerializeField] private bool isActiveByDefault;

            public void Switch(bool isActive)
            {
                if (isActive) objectToSwitch.Switch(!isActiveByDefault);
                else objectToSwitch.Switch(isActiveByDefault);
            }
        }
    }
}
