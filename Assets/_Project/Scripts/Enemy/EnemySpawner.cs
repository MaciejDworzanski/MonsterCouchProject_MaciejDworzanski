using System;
using System.Collections.Generic;
using _Project.Scripts.Player;
using UnityEngine;

namespace _Project.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private int numberOfEnemiesToSpawn = 1000;

        [SerializeField]
        private PlayerCollisionTrigger playerCollisionTrigger;

        [SerializeField]
        private Enemy enemyPrefab;

        [SerializeField]
        private List<Transform> positionToSpawnEnemies;

        private int lastSpawnedEnemyPositionNumber;

        private Material materialToAddToEnemies;

        [SerializeField]
        private List<Enemy> enemies;

        private void Start()
        {
            materialToAddToEnemies = Resources.Load<Material>("EnemyMaterial");
            SpawnEnemies();
        }

        private void Update()
        {
            foreach (var enemy in enemies)
            {
                enemy.UpdateEnemy();
            }
        }

        private void SpawnEnemies()
        {
            for (var i = 0; i < numberOfEnemiesToSpawn; i++)
            {
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            var position = GetPositionToSpawnNextEnemy();
            var newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity, transform);
            newEnemy.Initialize(playerCollisionTrigger, materialToAddToEnemies);
            enemies.Add(newEnemy);
        }

        private Vector3 GetPositionToSpawnNextEnemy()
        {
            lastSpawnedEnemyPositionNumber++;
            if (lastSpawnedEnemyPositionNumber >= positionToSpawnEnemies.Count)
                lastSpawnedEnemyPositionNumber = 0;
            return positionToSpawnEnemies[lastSpawnedEnemyPositionNumber].position;
        }
    }
}