using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public class MainMenuWindow : WindowBase
    {
        [SerializeField]
        private Button playButton, settingsButton, exitButton;

        public static event Action OnPlayButtonClicked, OnSettingsButtonClicked, OnExitButtonClicked; 

        private void OnEnable()
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(PlayButtonClicked);
            
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(SettingsButtonClicked);
            
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(ExitButtonClicked);
        }

        private void PlayButtonClicked()
        {
            OnPlayButtonClicked?.Invoke();
        }
        
        private void SettingsButtonClicked()
        {
            OnSettingsButtonClicked?.Invoke();
        }
        
        private void ExitButtonClicked()
        {
            OnExitButtonClicked?.Invoke();
        }

        private void OnDisable()
        {
            
        }

        public override bool CanBeClosedViaEscapeButton()
        {
            return false;
        }
    }
}