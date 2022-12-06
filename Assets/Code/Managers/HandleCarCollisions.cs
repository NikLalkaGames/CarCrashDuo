using System;
using Code.Level;
using UnityEngine;

namespace Code.Managers
{
    public class HandleCarCollisions : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Obstacle")) return;
            
            if (collision.gameObject.TryGetComponent(out VehicleObstacle vehicleObstacle))
            {
                _healthController.ChangeHealth(-33);
            }
            else
            {
                collision.rigidbody.AddForce(new Vector3(0,1,1) * 5, ForceMode.Impulse);
            }
        }
    }
}