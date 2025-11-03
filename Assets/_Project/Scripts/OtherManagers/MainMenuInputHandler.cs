using System;
using UnityEngine;

namespace _Project.Scripts.SceneControllers
{
    public class MainMenuInputHandler : MonoBehaviour
    {
        public static event Action OnEscapeClicked;
        
        private void Update()
        {
            OnEscapeClicked?.Invoke();
        }
    }
}