using System.Collections.Generic;
using System.Linq;
using Code.Common.Containers;
using Code.Common.Events;
using Code.Common.ObjectPool;
using UnityEngine;

namespace Code.Level
{
    public class RoadSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerPlaces _playerPlaces;
        [SerializeField] private GameObject _roadPrefab;
        [SerializeField] private List<GameObject> _spawnedRoads;
        [SerializeField] private float _spawningOffset = 100f;
        [SerializeField] private float _carAllowedDistance = 200f;

        private bool RequiredDistanceSpawning =>
            _playerPlaces.PlayerCarsOrdered.First().position.z - _playerPlaces.PlayerCarsOrdered.Last().position.z >
            _carAllowedDistance;
        
        private void Start()
        {
            // initial spawn location
            _spawnedRoads.Add(PoolManager.SpawnObject(_roadPrefab, _roadPrefab.transform.position, Quaternion.identity));
            SpawnNextRoad();
            SpawnNextRoad();
            SpawnNextRoad();
        }

        public void SpawnNextRoad()
        {
            Vector3 nextSpawnPos = _spawnedRoads.Last().transform.position;
            _spawnedRoads.Add(
                PoolManager.SpawnObject(_roadPrefab, 
                    new Vector3(nextSpawnPos.x, 
                        nextSpawnPos.y,
                        nextSpawnPos.z + _spawningOffset), 
                    Quaternion.identity));
        } 

        public void HandleRequirementForRoadSpawning()
        {
            if (RequiredDistanceSpawning)
            {
                SpawnNextRoad();
            }
        }

        public void ReleaseRoad()
        {
            var roadToRelease = _spawnedRoads.First();
            PoolManager.ReleaseObject(roadToRelease);
            _spawnedRoads.Remove(roadToRelease);
        }

    }
}