using System;
using Common.Containers;
using Common.ObjectPool;
using UnityEngine;

namespace LevelGeneration
{
    public class GarbageCleaner : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                PoolManager.ReleaseObject(other.gameObject);
            }
        }
    }
}