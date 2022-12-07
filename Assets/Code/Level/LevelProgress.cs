using System;
using System.Collections.Generic;
using Code.Common;
using Code.Common.Events;
using Code.Managers;
using Code.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Level
{
    public class LevelProgress : MonoBehaviour
    {
        private float _timer;
        [SerializeField] private float _levelTime;     // 120
        [SerializeField] private UILevelTimer _uiLevelTimerFirst;

        private void Start()
        {
            _timer = _levelTime;
        }

        private void Update()
        {
            _uiLevelTimerFirst.UpdateTime(_timer);
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                return;
            }

            SceneManager.LoadScene("LevelFinish");
        }
    }
}