using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraFollowVehicle : MonoBehaviour
    {
        [SerializeField] private Transform _vehicleTransform;
        
        private Vector3 _offset;

        private Transform _camTransform;

        [SerializeField] private float _smoothSpeed;
        
        private void Start()
        {
            _camTransform = transform;
            _offset = _vehicleTransform.position - _camTransform.position;
        }

        // TODO: replace to cinemachine
        private void LateUpdate()
        {
            var vehiclePos = _vehicleTransform.position;
            Vector3 desiredPosition = new Vector3(vehiclePos.x, vehiclePos.y - _offset.y, vehiclePos.z - _offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}