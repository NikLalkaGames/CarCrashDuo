using System.Collections.Generic;
using System.Linq;
using Code.Common.Containers;
using Code.Common.ObjectPool;
using UnityEngine;

namespace Code.Level
{
    public class PoolInit : MonoBehaviour
    {
        [SerializeField] private List<PoolContainer> _poolContainers;

        private void Awake()
        {
            foreach (var pooledModel in _poolContainers.SelectMany(poolContainer => poolContainer.Pools))
            {
                PoolManager.WarmPool(pooledModel.Prefab, pooledModel.Size);
            }
        }
    }
}