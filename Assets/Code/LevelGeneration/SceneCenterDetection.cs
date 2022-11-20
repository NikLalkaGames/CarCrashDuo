using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.LevelGeneration
{
    public class SceneCenterDetection : MonoBehaviour
    {
        private Transform _sceneCenterTransform;

        [SerializeField] private List<Transform> _activePlayerTransforms;

        private void Start()
        {
            _sceneCenterTransform = transform;
            _sceneCenterTransform.position = Vector3.zero;
        }

        private void Update()
        {
            float averageDepth = _activePlayerTransforms.Sum(playerTransform => playerTransform.position.z) / _activePlayerTransforms.Count;
            var newPos = _sceneCenterTransform.position;
            _sceneCenterTransform.position = new Vector3(newPos.x, newPos.y, averageDepth);
        }
    }
}