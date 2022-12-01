﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private string _playButtonScene;
        [SerializeField] private string _settingsButtonScene;
        [SerializeField] private string _creditsButtonScene;

        public void OnPlayButtonClicked()
        {
            SceneManager.LoadScene(_playButtonScene);
        }
        public void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }
}