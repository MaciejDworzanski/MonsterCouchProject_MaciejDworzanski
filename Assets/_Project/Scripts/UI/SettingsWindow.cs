using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public class SettingsWindow : WindowBase
    {
        [SerializeField]
        private Button backButton;

        private void OnEnable()
        {
            MainMenuWindow.OnSettingsButtonClicked += Initialize;
            
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(BackButtonClicked);
        }

        private void OnDisable()
        {
            MainMenuWindow.OnSettingsButtonClicked -= Initialize;
        }

        private void Initialize()
        {
            Open();
        }
        
        private void BackButtonClicked()
        {
            Close();
        }
    }
}