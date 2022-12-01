using System.Collections.Generic;
using System.Linq;
using Code.Common.RuntimeSet.Instances;
using UnityEngine;

namespace Code.Level
{
    public class SceneCenterDetection : MonoBehaviour
    {
        private Transform _sceneCenterTransform;

        [SerializeField] private TransformRuntimeSet _runtimeCars;

        private void Start()
        {
            _sceneCenterTransform = transform;
            _sceneCenterTransform.position = Vector3.zero;
        }

        private void Update()
        {
            float averageDepth = _runtimeCars.Items.Sum(playerTransform => playerTransform.position.z) / _runtimeCars.Items.Count;
            var newPos = _sceneCenterTransform.position;
            _sceneCenterTransform.position = new Vector3(newPos.x, newPos.y, averageDepth);
        }
    }
}