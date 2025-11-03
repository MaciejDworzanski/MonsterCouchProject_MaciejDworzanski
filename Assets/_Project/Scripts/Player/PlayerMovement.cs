using System;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput playerInput;

        private Camera cam;

        private void OnEnable()
        {
            cam = Camera.main;
            playerInput.OnPlayerMove += PlayerMove;
        }

        private void OnDisable()
        {
            playerInput.OnPlayerMove -= PlayerMove;
        }

        private void PlayerMove(Vector2 obj)
        {

            KeepInsideCamera();
        }
        
        private void KeepInsideCamera()
        {
            var pos = transform.position;
            var viewportPos = cam.WorldToViewportPoint(pos);

            viewportPos.x = Mathf.Clamp01(viewportPos.x);
            viewportPos.y = Mathf.Clamp01(viewportPos.y);

            pos = cam.ViewportToWorldPoint(viewportPos);
            transform.position = pos;
        }
    }
}