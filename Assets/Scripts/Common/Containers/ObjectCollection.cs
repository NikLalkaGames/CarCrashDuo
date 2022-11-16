﻿using UnityEngine;

namespace Common.Containers
{
    [CreateAssetMenu(fileName = "Object/ObjectCollection")]
    public class ObjectCollection : ScriptableObject
    {
        public GameObject[] Objects;
    }
}