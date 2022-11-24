using System;
using Code.UI;
using UnityEngine;

namespace Code.Level
{
    public class LevelProgress : MonoBehaviour
    {
        private float _timer;
        
        [SerializeField] private float _levelTime;     // 120

        [SerializeField] private UILevelTimer _uiLevelTimerFirst;
        
        [SerializeField] private UILevelTimer _uiLevelTimerSecond;
        
        // restart level screen

        private void Start()
        {
            _timer = _levelTime;
        }

        private void Update()
        {
            _uiLevelTimerFirst.UpdateTime(_timer);
            _uiLevelTimerSecond.UpdateTime(_timer);
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                return;
            }
            
            
            // go to finish scene
        }
    }
}