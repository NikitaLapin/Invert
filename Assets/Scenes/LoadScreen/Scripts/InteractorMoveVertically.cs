using System;
using UnityEngine;

namespace LoadScreen.Scripts
{
    public class InteractorMoveVertically : InteractApplier
    {
        [SerializeField] private float moveMagnitude;
        [SerializeField] private float moveTime = 0.5f;
        [SerializeField] private bool isUpOnActive;

        private Vector3 _startPosition;

        private void Awake() => _startPosition = transform.position;

        public override void Switch(bool isActive)
        {
            switch (isActive)
            {
                case true when isUpOnActive:
                    LeanTween.moveY(gameObject, _startPosition.y + moveMagnitude, moveTime);
                    break;
                case true when !isUpOnActive:
                    LeanTween.moveY(gameObject, _startPosition.y, moveTime);
                    break;
                case false when isUpOnActive:
                    LeanTween.moveY(gameObject, _startPosition.y, moveTime);
                    break;
                case false when !isUpOnActive:
                    LeanTween.moveY(gameObject, _startPosition.y + moveMagnitude, moveTime);
                    break;
                default: throw new ArgumentException("Not implemented");
            }
        }
    }
}
