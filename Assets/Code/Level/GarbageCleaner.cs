﻿using Code.Common.ObjectPool;
using UnityEngine;

namespace Code.Level
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