using System;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action<Vector2> OnPlayerMove;
        
        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            var moveX = Input.GetAxis("Horizontal");
            var moveY = Input.GetAxis("Vertical");
            var movementVector = new Vector2(moveX, moveY);
            OnPlayerMove?.Invoke(movementVector);
        }
    }
}
