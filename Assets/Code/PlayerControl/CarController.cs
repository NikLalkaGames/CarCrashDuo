using UnityEngine;

namespace Code.PlayerControl
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private string HORIZONTAL = "Horizontal";  // const input axis
        [SerializeField] private string VERTICAL = "Vertical";      // const input axis
        [SerializeField] private KeyCode BREAK_KEY_CODE;

        private float _horizontalInput;
        private float _verticalInput;
        private float _currentSteerAngle;
        private float _currentBreakForce;
        private bool _isBreaking;

        [SerializeField] private float _motorForce;
        [SerializeField] private float _breakForce;
        [SerializeField] private float _maxSteerAngle;

        [SerializeField] private WheelCollider _frontLeftWheelCollider;
        [SerializeField] private WheelCollider _frontRightWheelCollider;
        [SerializeField] private WheelCollider _rearLeftWheelCollider;
        [SerializeField] private WheelCollider _rearRightWheelCollider;

        [SerializeField] private Transform _frontLeftWheelTransform;
        [SerializeField] private Transform _frontRightWheeTransform;
        [SerializeField] private Transform _rearLeftWheelTransform;
        [SerializeField] private Transform _rearRightWheelTransform;

        private void FixedUpdate()
        {
            GetInput();
            HandleMotor();
            HandleSteering();
            UpdateWheels();
        }


        private void GetInput()
        {
            _horizontalInput = Input.GetAxis(HORIZONTAL);
            _verticalInput = Input.GetAxis(VERTICAL);
            _isBreaking = Input.GetKey(BREAK_KEY_CODE);
        }

        private void HandleMotor()
        {
            _frontLeftWheelCollider.motorTorque = _verticalInput * _motorForce;       // forward mv control by player
            _frontRightWheelCollider.motorTorque = _verticalInput * _motorForce;      // forward mv control by player
            
            _currentBreakForce = _isBreaking ? _breakForce : 0f;
            ApplyBreaking();
        }

        private void ApplyBreaking()
        {
            _frontRightWheelCollider.brakeTorque = _currentBreakForce;
            _frontLeftWheelCollider.brakeTorque = _currentBreakForce;
            _rearLeftWheelCollider.brakeTorque = _currentBreakForce;
            _rearRightWheelCollider.brakeTorque = _currentBreakForce;
        }

        private void HandleSteering()
        {
            _currentSteerAngle = _maxSteerAngle * _horizontalInput;
            _frontLeftWheelCollider.steerAngle = _currentSteerAngle;
            _frontRightWheelCollider.steerAngle = _currentSteerAngle;
        }

        private void UpdateWheels()
        {
            UpdateSingleWheel(_frontLeftWheelCollider, _frontLeftWheelTransform);
            UpdateSingleWheel(_frontRightWheelCollider, _frontRightWheeTransform);
            UpdateSingleWheel(_rearRightWheelCollider, _rearRightWheelTransform);
            UpdateSingleWheel(_rearLeftWheelCollider, _rearLeftWheelTransform);
        }

        private static void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
        {
            wheelCollider.GetWorldPose(out var pos, out var rot);
            wheelTransform.rotation = rot;
            wheelTransform.position = pos;
        }
    }
}