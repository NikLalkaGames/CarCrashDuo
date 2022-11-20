using UnityEngine;

namespace Code.Control
{
    public class VehicleController : MonoBehaviour
    {
        [SerializeField] private InputHandler _inputHandler;

        [SerializeField] private float _turnSpeed;

        [SerializeField] private float _forwardSpeed;

        [SerializeField] private Rigidbody _rigidbody;
        
        private void Update()
        {
            transform.Translate(Time.deltaTime * _forwardSpeed * Vector3.forward);
            transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _inputHandler.InputAxis);
            
            // _rigidbody.MovePosition(transform.position + Time.fixedDeltaTime * _forwardSpeed * Vector3.forward);
            // var deltaRotation = Quaternion.AngleAxis( Time.fixedDeltaTime * _turnSpeed * _inputHandler.InputAxis, Vector3.up);
            // _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
        }
    }
}
