using UnityEngine;

namespace Code.PlayerControl
{
    public class VehicleController : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;

        [SerializeField] private float _turnSpeed;

        [SerializeField] private float _forwardSpeed;

        [SerializeField] private Rigidbody _rigidbody;
        
        private void FixedUpdate()
        {
            //transform.Translate(Time.deltaTime * _forwardSpeed * Vector3.forward);

            var newPos = _rigidbody.position +
                           transform.TransformDirection(Time.fixedDeltaTime * _forwardSpeed * Vector3.forward);
            _rigidbody.MovePosition(newPos);
            
            var deltaRotation = Quaternion.AngleAxis( Time.fixedDeltaTime * _turnSpeed * _inputHandler.HzAxis, Vector3.up);
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        }
    }
}
