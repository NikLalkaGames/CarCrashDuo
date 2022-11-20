using UnityEngine;

namespace Code.Control
{
    public class PlaneController : MonoBehaviour
    {
        [SerializeField] private float _forwardSpeed;
        [SerializeField] private float _rotationSpeed;
        private Vector3 _movementRotation;
    
        private void Update()
        {
            _movementRotation.y = Input.GetAxis("Vertical");
            _movementRotation.x = Input.GetAxis("Horizontal");
        
            transform.Translate(Time.deltaTime * _forwardSpeed * Vector3.forward);
            transform.Rotate(Vector3.up, Time.deltaTime * _rotationSpeed * _movementRotation.x);
            transform.Rotate(Vector3.right, Time.deltaTime * _rotationSpeed * _movementRotation.y);
        }
    }

}
