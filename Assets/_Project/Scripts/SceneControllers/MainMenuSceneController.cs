using System;
using _Project.Scripts.UI;
using UnityEngine;

namespace _Project.Scripts.SceneControllers
{
    public class MainMenuSceneController : MonoBehaviour
    {
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
            
        }

        private void CloseGame()
        {
            Application.Quit();
        }
    }
}
