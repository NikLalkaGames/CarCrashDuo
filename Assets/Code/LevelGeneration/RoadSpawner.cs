using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.LevelGeneration
{
    public class RoadSpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> _roads;

        private const float OFFSET = 200f;

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
            var nextDepthPos = _roads.Last().position.z + OFFSET;
            movedRoad.position = new Vector3(0, 0, nextDepthPos);
            _roads.Add(movedRoad);
        }
    }
}