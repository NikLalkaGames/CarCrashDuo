using System;
using System.Collections.Generic;
using Code.Common;
using TMPro;
using UnityEngine;

namespace Code.UI.LevelFinish
{
    public class FillPlayerStats : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _place;
        [SerializeField] private TextMeshProUGUI _points;
        [SerializeField] private TextMeshProUGUI _health;
        [SerializeField] private PlayerInfo _playerInfo;

        private void Start()
        {
            _place.text = $"{_playerInfo.Place}";
            _points.text = $"{_playerInfo.Score}";
            _health.text = $"{_playerInfo.Health}";
        }
    }
}