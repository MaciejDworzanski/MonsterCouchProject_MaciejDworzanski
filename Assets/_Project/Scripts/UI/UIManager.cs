using System.Collections.Generic;
using _Project.Scripts.SceneControllers;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        private List<WindowBase> openWindows = new();
        
        private void OnEnable()
        {
            WindowBase.OnOpen += WindowOpen;
            WindowBase.OnClose += WindowClosed;
            MainMenuInputHandler.OnEscapeClicked += TryCloseLastWindowWithEscapeButton;
        }

        private void OnDisable()
        {
            WindowBase.OnOpen -= WindowOpen;
            WindowBase.OnClose -= WindowClosed;
            MainMenuInputHandler.OnEscapeClicked -= TryCloseLastWindowWithEscapeButton;
        }

        private void WindowClosed(WindowBase window)
        {
            openWindows.Remove(window);
        }

        private void WindowOpen(WindowBase window)
        {
            openWindows.Add(window);
        }

        private void TryCloseLastWindowWithEscapeButton()
        {
            if (openWindows.Count == 0)
                return;
            var lastWindow = openWindows[^1];
            if(lastWindow.CanBeClosedViaEscapeButton())
                lastWindow.Close();
        }
    }
}
