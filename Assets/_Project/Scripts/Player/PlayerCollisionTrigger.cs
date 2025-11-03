using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerCollisionTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Enemy.Enemy>(out var enemy))
            {
                enemy.CatchEnemy();
            }
        }
    }
}