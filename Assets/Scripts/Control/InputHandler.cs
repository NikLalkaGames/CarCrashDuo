using System;
using UnityEngine;

namespace Control
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private string _inputType;

        public float InputAxis { get; private set; }

        private void Update()
        {
            InputAxis = Input.GetAxis(_inputType);
        }
    }
}