using UnityEngine;

namespace Code.LevelGeneration
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
            if (_detectionCounter < _numberOfCars) return;
            _roadSpawner.MoveRoadBack();
            _detectionCounter = 0;
        }
    }
}