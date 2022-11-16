using UnityEngine;

namespace Common.Behaviours
{
    public class FollowObject : MonoBehaviour
    {
        [SerializeField] private Transform _followedTransform;
        
        private Vector3 _offset;

        private Transform _followerTransform;

        [SerializeField] private float _smoothSpeed;
        
        private void Start()
        {
            _followerTransform = transform;
            _offset = _followedTransform.position - _followerTransform.position;
        }

        // TODO: replace to cinemachine
        private void LateUpdate()
        {
            var vehiclePos = _followedTransform.position;
            Vector3 desiredPosition = new Vector3(vehiclePos.x, vehiclePos.y - _offset.y, vehiclePos.z - _offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}