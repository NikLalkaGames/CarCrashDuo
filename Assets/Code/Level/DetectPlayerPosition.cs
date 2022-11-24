using System;
using System.Collections.Generic;
using System.Linq;
using Code.Common.Models;
using Code.UI;
using UnityEngine;

namespace Code.Level
{
    public class DetectPlayerPosition : MonoBehaviour
    {
        [SerializeField] private PlayerPosition _firstPlayerPosition;

        [SerializeField] private PlayerPosition _secondPlayerPosition;

        [SerializeField] private UIPlayerPos _uiPlayerPos;

        private void Update()
        {
            if (_firstPlayerPosition.Transform.position.z > _secondPlayerPosition.Transform.position.z)
            {
                _firstPlayerPosition.PositionNumber = 1;
                _secondPlayerPosition.PositionNumber = 2;
            }
            else if (_firstPlayerPosition.Transform.position.z < _secondPlayerPosition.Transform.position.z)
            {
                _firstPlayerPosition.PositionNumber = 2;
                _secondPlayerPosition.PositionNumber = 1;
            }
            
            _uiPlayerPos.UpdatePositions(_firstPlayerPosition.PositionNumber, _secondPlayerPosition.PositionNumber);
        }
        
        
    }
}