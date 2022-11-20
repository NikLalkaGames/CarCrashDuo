using UnityEngine;

namespace Code.Common.Containers
{
    [CreateAssetMenu(menuName = "Pools/Pool", order = 0)]
    public class Pool : ScriptableObject
    {
        public GameObject Prefab;

        public int Size;
    }
}