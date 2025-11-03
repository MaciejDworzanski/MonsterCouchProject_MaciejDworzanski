using System;
using _Project.Scripts.Player;
using UnityEngine;

namespace _Project.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed = 1f;
        
        private Rigidbody2D enemyRigidbody;

        private PlayerCollisionTrigger playerCollisionTrigger;

        private Camera cam;

        private bool wasFound = false;

        public void Initialize(PlayerCollisionTrigger trigger)
        {
            playerCollisionTrigger = trigger;
            cam = Camera.main;
        }

        private void Update()
        {
            if (wasFound)
                return;
            MoveAwayFromPlayer();
        }

        private void MoveAwayFromPlayer()
        {
            var playerPosition = playerCollisionTrigger.transform.position;
            var direction = (transform.position - playerPosition).normalized;

            transform.position += (movementSpeed * Time.deltaTime * direction);

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

        public void CatchEnemy()
        {
            wasFound = true;
        }
    }
}
