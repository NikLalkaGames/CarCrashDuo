using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.UI
{
    public class PauseMenu : MonoBehaviour
    {
        private static bool _gameIsPaused = false;
        public GameObject pauseMenuUI;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)){
                if (_gameIsPaused){
                    Resume();
                } else {
                    Pause();
                }
            }
        }

        public void Resume(){
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            _gameIsPaused = false;
        }

        void Pause(){
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            _gameIsPaused = true;
        }

        public void GoToMenu(){
            _gameIsPaused = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Return to Menu");
        }

        public void ExitGame(){
            Application.Quit ();
            Debug.Log("Quit");
        }

        public void Restart(){
            Debug.Log("Reloading scene");
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}