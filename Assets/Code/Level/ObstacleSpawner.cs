﻿using System.Collections.Generic;
using System.Linq;
using Code.Common.Containers;
using Code.Common.ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Level
{
    public class ObstacleSpawner : MonoBehaviour
    {
        private float _timer = 0f;

        [SerializeField] private PoolContainer _poolContainer;
        [SerializeField] private List<GameObject> _obstaclePrefabCollection = new List<GameObject>();
        [SerializeField] private PlayerPlaces _playerPlaces;
        
        [SerializeField] private float _timeUntilNextSpawn;     // spawn rate
        [SerializeField] private float _generationOffset;                 // offset of vehicle for generation obstacles
        [SerializeField] private int _minObsToSpawnOnHorizontalLine;
        [SerializeField] private int _maxObsToSpawnOnHorizontalLine;
        [SerializeField] private float _initialOffset;
        [Range(-8,8)] [SerializeField] private int leftHorizontalBoundary, RightHorizontalBoundary;

        private void Start()
        {
            foreach (var poolModel in _poolContainer.Pools)
            {
                _obstaclePrefabCollection.Add(poolModel.Prefab);
            }
            
            // InitialGeneration();
        }
        
        private void InitialGeneration()
        {
            while (_initialOffset < _generationOffset)
            {
                for (int i = 0; i < Random.Range(_minObsToSpawnOnHorizontalLine, _maxObsToSpawnOnHorizontalLine); i++)
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
            for (int i = 0; i < Random.Range(_minObsToSpawnOnHorizontalLine, _maxObsToSpawnOnHorizontalLine); i++)
            {
                GenerateRandomObstacle(_generationOffset);
            }
            
        }

        private void GenerateRandomObstacle(float offset)
        {
            PoolManager.SpawnObject(
                GetRandomObject(),
                GetSpawnPosition(offset),
                Quaternion.AngleAxis(180, Vector3.up));
        }
        
        private GameObject GetRandomObject() => _obstaclePrefabCollection[Random.Range(0, _obstaclePrefabCollection.Count)];

        private Vector3 GetSpawnPosition(float offset)
        {
            var vp = _playerPlaces.PlayerCarsOrdered.First().position;
            return new Vector3(Random.Range(leftHorizontalBoundary, RightHorizontalBoundary), vp.y, vp.z + offset);
        }
    }
}