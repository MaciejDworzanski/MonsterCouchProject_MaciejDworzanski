using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public abstract class WindowBase : MonoBehaviour
    {
        public static event Action<WindowBase> OnOpen, OnClose;

        [SerializeField]
        private GameObject content;

        [SerializeField]
        private bool OpenOnStart;

        [SerializeField]
        private Selectable defaultSelectable;

        private void Start()
        {
            if (OpenOnStart)
                Open();
            else
                Close();
        }

        public void Open()
        {
            if (!CanOpen())
                return;
            content.SetActive(true);
            OnOpen?.Invoke(this);
            SelectDefaultOrLastSelectedButton();
        }

        public void Close()
        {
            content.SetActive(false);
            OnClose?.Invoke(this);
        }

        private void SelectDefaultOrLastSelectedButton()
        {
            EventSystem.current.SetSelectedGameObject(defaultSelectable.gameObject);
        }

        protected virtual bool CanOpen()
        {
            return true;
        }

        public virtual bool CanBeClosedViaEscapeButton()
        {
            return true;
        }
    }
}