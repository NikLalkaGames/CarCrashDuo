using UnityEngine;

namespace Code.Level
{
    public class VehicleObstacle : MonoBehaviour
    {
        [SerializeField] private float _turnSpeed;

        [SerializeField] private float _forwardSpeed;

        [SerializeField] private Rigidbody _rigidbody;
        
        private void FixedUpdate()
        {
            var newPos = _rigidbody.position +
                           transform.TransformDirection(Time.fixedDeltaTime * _forwardSpeed * Vector3.forward);
            _rigidbody.MovePosition(newPos);

            // var deltaRotation = Quaternion.AngleAxis( Time.fixedDeltaTime * _turnSpeed * Input.GetAxis("Horizontal"), Vector3.up);
            // _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        }
    }
}
