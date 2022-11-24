using System.Collections.Generic;
using Code.Common.Containers;
using Code.Common.ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Level
{
    public class ObstacleSpawner : MonoBehaviour
    {
        private readonly List<GameObject> _obstacleCollection = new List<GameObject>();

        [SerializeField] private PoolContainer _poolContainer;

        [SerializeField] private Transform _levelTransform;

        private float _timer = 0f;

        [SerializeField] private float _timeUntilNextSpawn;     // spawn rate
        
        [SerializeField] private float _generationOffset;                 // offset of vehicle for generation obstacles

        [SerializeField] private int _minObsToSpawnOnXLine;

        [SerializeField] private int _maxObsToSpawnOnXLine;

        [SerializeField] private float _initialOffset;

        private void Start()
        {
            foreach (var obs in _poolContainer.Pools)  
                _obstacleCollection.Add(obs.Prefab);

            InitialGeneration();
        }
        
        private void InitialGeneration()
        {
            while (_initialOffset < _generationOffset)
            {
                for (int i = 0; i < Random.Range(_minObsToSpawnOnXLine, _maxObsToSpawnOnXLine); i++)
                {
                    GenerateRandomObstacle(_initialOffset);
                }

                _initialOffset += 40f;
            }
        }
        
        private void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                return;
            }

            _timer = _timeUntilNextSpawn;    // update timer for spawning new obstacles
            for (int i = 0; i < Random.Range(_minObsToSpawnOnXLine, _maxObsToSpawnOnXLine); i++)
            {
                GenerateRandomObstacle(_generationOffset);
            }
            
        }

        private void GenerateRandomObstacle(float offset)
        {
            PoolManager.SpawnObject(
                GetRandomObject(),
                GetSpawnPosition(offset),
                Quaternion.identity);
        }
        
        private GameObject GetRandomObject() => _obstacleCollection[Random.Range(0, _obstacleCollection.Count)];

        private Vector3 GetSpawnPosition(float offset)
        {
            var vp = _levelTransform.position;
            return new Vector3(Random.Range(-8, 8), vp.y, vp.z + offset);
        }
    }
}