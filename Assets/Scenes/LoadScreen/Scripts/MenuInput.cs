using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LoadScreen.Scripts
{
    public class MenuInput : MonoBehaviour
    {
        [SerializeField] private List<GameObject> menus;
        [SerializeField] private InputAction closeMenu;

        private void OnEnable()
        {
            closeMenu.Enable();

            closeMenu.started += CloseMenu;
        }

        private void OnDisable()
        {
            closeMenu.Enable();

            foreach (var menu in menus) menu.SetActive(false);

            closeMenu.started -= CloseMenu;
        }

        private void CloseMenu(InputAction.CallbackContext context)
        {
            gameObject.SetActive(false);
        }
    }
}
