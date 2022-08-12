using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LoadScreen.Scripts
{
    public class InteractiveTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action<bool> Triggered;

        public void OnPointerEnter(PointerEventData eventData) => Triggered?.Invoke(true);
        public void OnPointerExit(PointerEventData eventData) => Triggered?.Invoke(false);
    }
}
