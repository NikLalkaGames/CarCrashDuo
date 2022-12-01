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
        
        [SerializeField] private float _spawningOffset = 200f;

        public bool RequireDistanceSpawning =>
            _playerPlaces.PlayerCarsOrdered.First().position.z - _playerPlaces.PlayerCarsOrdered.Last().position.z >
            _spawningOffset;
        
        private void Start()
        {
            _spawnedRoads.Add(PoolManager.SpawnObject(_roadPrefab, _roadPrefab.transform.position, Quaternion.identity));
            SpawnNextRoad();
        }

        private void SpawnNextRoad()
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
            if (RequireDistanceSpawning)
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