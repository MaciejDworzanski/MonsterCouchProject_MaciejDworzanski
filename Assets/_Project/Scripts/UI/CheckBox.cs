using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public class CheckBox : MonoBehaviour
    {
        public event Action<bool> OnStateChanged;
        
        [SerializeField]
        private Button CheckBoxButton;

        [SerializeField]
        private TextMeshProUGUI checkboxButtonText;

        [SerializeField]
        private bool IsOnFromStart;
        
        private bool currentState;

        private void OnEnable()
        {
            CheckBoxButton.onClick.RemoveAllListeners();
            CheckBoxButton.onClick.AddListener(ToggleState);
        }

        private void Start()
        {
            if (IsOnFromStart)
                SetStateToOn();
            else
                SetStateToOff();
        }

        private void ToggleState()
        {
            if(currentState)
                SetStateToOff();
            else
                SetStateToOn();
        }

        private void SetStateToOn()
        {
            checkboxButtonText.text = "X";
            currentState = true;
            RefreshState();
        }
        
        private void SetStateToOff()
        {
            checkboxButtonText.text = " ";
            currentState = false;
            RefreshState();
        }

        private void RefreshState()
        {
            checkboxButtonText.text = currentState ? "X" : " ";
            OnStateChanged?.Invoke(currentState);
        }
    }
}