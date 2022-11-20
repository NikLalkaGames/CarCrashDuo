using UnityEngine;

namespace Code.LevelGeneration
{
    public class RoadSpawnDetector : MonoBehaviour
    {
        [SerializeField] private RoadSpawner _roadSpawner;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("SpawnTrigger"))
            {
                _roadSpawner.MoveRoadBack();
            }
        }
    }
}