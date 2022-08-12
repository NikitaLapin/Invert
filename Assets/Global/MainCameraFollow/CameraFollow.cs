using UnityEngine;

namespace Global.MainCameraFollow
{
    public class CameraFollow : MonoBehaviour
    {
        #region Initialization

        [SerializeField] private Transform target;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private Vector3 offset;
        private Transform _cameraTransform;

        #endregion

        private void Awake() => _cameraTransform = GetComponent<Transform>();

        private void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(_cameraTransform.position, desiredPosition, smoothSpeed);
            _cameraTransform.position = smoothedPosition;
            
            _cameraTransform.LookAt(target);
        }
    }
}
