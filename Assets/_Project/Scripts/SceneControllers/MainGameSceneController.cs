using System;
using _Project.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.SceneControllers
{
    public class MainGameSceneController : MonoBehaviour
    {
        private void OnEnable()
        {
            PlayerInput.OnPlayerWantsToExit += QuitScene;
        }

        private void OnDisable()
        {
            PlayerInput.OnPlayerWantsToExit -= QuitScene;
        }

        private void QuitScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}