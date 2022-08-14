using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scenes.LoadScreen.Scripts
{
    public class InteractiveTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public event Action<bool> Triggered;
        public event Action Clicked; 

        public void OnPointerEnter(PointerEventData eventData) => Triggered?.Invoke(true);
        public void OnPointerExit(PointerEventData eventData) => Triggered?.Invoke(false);
        public void OnPointerClick(PointerEventData eventData) => Clicked?.Invoke();
    }
}