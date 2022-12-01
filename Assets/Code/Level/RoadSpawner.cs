using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.RuntimeSet;
using Code.Common.RuntimeSet.Instances;
using Code.PlayerControl;
using UnityEngine;

namespace Code.Level
{
    public class RoadSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerPlaces _playerPlaces;
        [SerializeField] private List<Transform> _roads;
        private const float SPAWNING_OFFSET = 200f;
        
        public bool RequireDistanceSpawning =>
            _playerPlaces.PlayerCarsOrdered.First().position.z - _playerPlaces.PlayerCarsOrdered.Last().position.z >
            SPAWNING_OFFSET;
        
        private void Start()
        {
            if (_roads == null || _roads.Count == 0)
            {
                Debug.LogError("You need to specify road collection for road spawning");
                return;
            }
            _roads = _roads.OrderBy(r => r.position.z).ToList();
        }



        public void MoveRoadBack()
        {
            var movedRoad = _roads[0];
            _roads.Remove(movedRoad);
            var nextDepthPos = _roads.Last().position.z + SPAWNING_OFFSET;
            movedRoad.position = new Vector3(0, 0, nextDepthPos);
            _roads.Add(movedRoad);
        }

    }
}