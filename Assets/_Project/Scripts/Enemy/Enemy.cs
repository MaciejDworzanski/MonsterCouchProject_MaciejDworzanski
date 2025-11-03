using System;
using _Project.Scripts.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed = 1f;

        [SerializeField]
        private SpriteRenderer spriteRenderer;
        
        private Rigidbody2D enemyRigidbody;

        private PlayerCollisionTrigger playerCollisionTrigger;

        private Camera cam;

        private bool wasFound = false;

        private int currentFrame;

        private int calculateEveryXFrame = 5;

        private Vector3 lastMovementVector;

        public void Initialize(PlayerCollisionTrigger trigger, Material material)
        {
            spriteRenderer.sharedMaterial = material; 
            playerCollisionTrigger = trigger;
            cam = Camera.main;
            movementSpeed *= Random.Range(0.8f, 1.2f);
        }

        public void UpdateEnemy()
        {
            if (wasFound)
                return;
            if (currentFrame < 30)
            {
                MoveAwayFromPlayer();
                currentFrame++;
                return;
            }

            currentFrame = 0;
            CalculateMovementVector();
            MoveAwayFromPlayer();
        }

        private void MoveAwayFromPlayer()
        {
            var direction = lastMovementVector;
            transform.position += movementSpeed * Time.deltaTime * direction;

            KeepInsideCamera();
        }

        private void CalculateMovementVector()
        {
            var playerPosition = playerCollisionTrigger.transform.position;
            var direction = (transform.position - playerPosition).normalized;
            lastMovementVector = direction;
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
