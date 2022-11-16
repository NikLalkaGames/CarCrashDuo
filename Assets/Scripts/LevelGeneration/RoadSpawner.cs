using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LevelGeneration
{
    public class RoadSpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> _roads;

        private static readonly float _offset = 200f;
    
        // save value of next road for spawning object

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
            var nextDepthPos = _roads.Last().position.z + _offset;
            movedRoad.position = new Vector3(0, 0, nextDepthPos);
            _roads.Add(movedRoad);
        }
    }
}