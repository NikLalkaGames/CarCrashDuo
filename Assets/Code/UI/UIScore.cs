using System;
using Code.Common;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreUIValue;

        [SerializeField] private PlayerInfo _playerInfo;
        
        public void Start() => _scoreUIValue.text = "0";

        private void Update()
        {
            _scoreUIValue.text = $"{_playerInfo.Score}";
        }
    }
}