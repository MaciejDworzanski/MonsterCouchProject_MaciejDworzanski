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
            Debug.Log($"Open window {gameObject.name}");
            content.SetActive(true);
            OnOpen?.Invoke(this);
            SelectDefaultButton();
        }

        public void Close()
        {
            Debug.Log($"Close window {gameObject.name}");
            content.SetActive(false);
            OnClose?.Invoke(this);
        }

        public void SelectDefaultButton()
        {
            EventSystem.current.SetSelectedGameObject(defaultSelectable.gameObject);
            Debug.Log($"Selecting {defaultSelectable.gameObject.name}");
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