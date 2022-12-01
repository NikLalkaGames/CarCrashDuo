using Code.Common.Events;
using UnityEngine;

namespace Code.Level
{
    public class RoadSpawnTrigger : MonoBehaviour
    {
        public GameEvent OnFirstCarEnterRoadSpawnTrigger;
        public GameEvent OnAllCarsEnterRoadSpawnTrigger;
        
        [SerializeField] private int _numberOfCars;
        private int _detectionCounter;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            
            _detectionCounter++;

            if (_detectionCounter == 1)
            {
                OnFirstCarEnterRoadSpawnTrigger.Raise();                
            }

            if (_detectionCounter < _numberOfCars) return;
            OnAllCarsEnterRoadSpawnTrigger.Raise();
            _detectionCounter = 0;
        }
    }
}