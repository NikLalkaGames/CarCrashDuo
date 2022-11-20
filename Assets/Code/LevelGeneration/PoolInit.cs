using Code.Common.Containers;
using Code.Common.ObjectPool;
using UnityEngine;

namespace Code.LevelGeneration
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