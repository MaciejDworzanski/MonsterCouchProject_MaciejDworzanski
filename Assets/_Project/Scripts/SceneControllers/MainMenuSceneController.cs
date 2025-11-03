using _Project.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.SceneControllers
{
    public class MainMenuSceneController : MonoBehaviour
    {
        private const int MainGameSceneNumber = 1;
        
        private void OnEnable()
        {
            MainMenuWindow.OnExitButtonClicked += CloseGame;
            MainMenuWindow.OnPlayButtonClicked += PlayButtonClicked;
        }

        private void OnDisable()
        {
            MainMenuWindow.OnExitButtonClicked -= CloseGame;
            MainMenuWindow.OnPlayButtonClicked -= PlayButtonClicked;
        }

        private void PlayButtonClicked()
        {
            SceneManager.LoadScene(MainGameSceneNumber);
        }

        private void CloseGame()
        {
            Application.Quit();
        }
    }
}
