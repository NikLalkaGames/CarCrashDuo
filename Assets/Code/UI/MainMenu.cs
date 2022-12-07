using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private string _playButtonScene;
        [SerializeField] private string _menuButtonScene;

        public void OnPlayButtonClicked()
        {
            SceneManager.LoadScene(_playButtonScene);
        }

        public void OnMainMenuButtonScene()
        {
            SceneManager.LoadScene(_menuButtonScene);
        }
        
        public void OnExitButtonClicked()
        {
            Application.Quit();
        }
    }
}