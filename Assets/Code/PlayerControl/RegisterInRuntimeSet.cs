using Code.Common.RuntimeSet.Instances;
using UnityEngine;

namespace Code.PlayerControl
{
    public class RegisterInRuntimeSet : MonoBehaviour
    {
        [SerializeField] private TransformRuntimeSet _carRuntimeSet;
        
        private void OnEnable()
        {
            _carRuntimeSet.Add(transform);    
        }
        
        private void OnDisable()
        {
            _carRuntimeSet.Remove(transform);    
        }
    }
}