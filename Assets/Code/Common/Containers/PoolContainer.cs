using UnityEngine;

namespace Code.Common.Containers
{
    [CreateAssetMenu(menuName = "Pools/PoolContainer", order = 0)]
    public class PoolContainer : ScriptableObject
    {
        public Pool[] Pools;
    }
}