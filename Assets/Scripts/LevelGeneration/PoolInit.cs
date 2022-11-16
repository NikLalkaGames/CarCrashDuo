using Common.Containers;
using Common.ObjectPool;
using UnityEngine;

namespace LevelGeneration
{
    public class PoolInit : MonoBehaviour
    {
        [SerializeField] private PoolContainer _poolContainer;

        private void Awake()
        {
            foreach (var pooledModel in _poolContainer.Pools)
            {
                PoolManager.WarmPool(pooledModel.Prefab, pooledModel.Size);
            }
        }
    }
}