using UnityEngine;

namespace LoadScreen.Scripts
{
    public abstract class InteractApplier : MonoBehaviour
    {
        public abstract void Switch(bool isActive);
    }
}