using UnityEngine;

namespace Code.Level
{
    public class RoadSpawnDetector : MonoBehaviour
    {
        [SerializeField] private RoadSpawner _roadSpawner;

        private int _detectionCounter;

        [SerializeField] private int _numberOfCars;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            _detectionCounter++;

            if (_detectionCounter == _numberOfCars)
            {
                
            }

            if (_detectionCounter >= _numberOfCars)
            {
                _roadSpawner.MoveRoadBack();
                _detectionCounter = 0;
            }


            // instantiate requirement = Car1.transform - Car2.transform > roadLength
        }
    }
}