using UnityEngine;

namespace Code.PlayerControl
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private string _horizontalInput;
        
        [SerializeField] private string _verticalInput;

        public float HzAxis { get; private set; }
        
        public float VrAxis { get; private set; }

        private void Update()
        {
            //VrAxis = Input.GetAxis(_verticalInput);
            HzAxis = Input.GetAxis(_horizontalInput);
        }
    }
}