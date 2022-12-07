using System;
using System.Collections.Generic;
using Code.Common;
using TMPro;
using UnityEngine;

namespace Code.UI.LevelFinish
{
    public class ShowWinner : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _winnerText;
        [SerializeField] private List<PlayerInfo> _playerInfos;
        
        private void Start()
        {
            string winner;

            if (_playerInfos[0].Place == 1 || _playerInfos[1].IsDead)
            {
                winner = "Red";
            }
            else
            {
                winner = "Blue";
            }
            
            _winnerText.text = winner;
        }
    }
}