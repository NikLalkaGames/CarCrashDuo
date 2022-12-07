using System;
using Code.Common;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Code.UI
{
    public class UIHealth : MonoBehaviour
    {
        [SerializeField] private Slider Health;
        
        [SerializeField] private PlayerInfo _playerInfo;

        private void Update()
        {
            Health.value = _playerInfo.Health;
        }
    }
}