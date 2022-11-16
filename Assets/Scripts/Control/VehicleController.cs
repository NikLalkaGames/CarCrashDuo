using UnityEngine;

namespace Control
{
    public class VehicleController : MonoBehaviour
    {
        private float _horizontalInput;

        [SerializeField] private float _turnSpeed;

        [SerializeField] private float _forwardSpeed;
    
        // Update is called once per frame
        private void Update()
        {
            ListenInput();
            Movement();
        }

        private void ListenInput()
        {
            _horizontalInput = Input.GetAxis("Horizontal");

        }

        private void Movement()
        {
            transform.Translate(Time.deltaTime * _forwardSpeed * Vector3.forward);
            transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
        }
    }
}
