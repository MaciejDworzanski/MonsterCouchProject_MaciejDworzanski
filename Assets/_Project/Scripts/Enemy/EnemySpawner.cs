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

        private void OnEnable()
        {
            
        }

        private void Start()
        {
            SpawnEnemies();
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
            newEnemy.Initialize(playerCollisionTrigger);
            Debug.Log("Spawn enemy");
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