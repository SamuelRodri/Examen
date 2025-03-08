using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;

    [SerializeField] private float hLimit;
    [SerializeField] private float vLimit;

    [SerializeField] private float timeSpawn;
    [SerializeField] private float limitTimeSpawn;
    [SerializeField] private float timeSpawnDecrement;
    [SerializeField] private float zombieSpeed;
    [SerializeField] private float speedIncrement;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float hRange;
    [SerializeField] private float vRange;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        timeSpawn -= timeSpawnDecrement * Time.deltaTime;
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (timeSpawn <= limitTimeSpawn)
            {
                timeSpawn = limitTimeSpawn;
            }

            Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

            if (-hRange < spawnPoint.x || spawnPoint.x > hRange)
            {
                spawnPoint.y = Random.Range(-vRange, vRange);
            }
            else if (-vRange < spawnPoint.y || spawnPoint.y > vRange)
            {
                spawnPoint.x = Random.Range(-hRange, hRange);
            }

            var zombie = Instantiate(zombiePrefab, spawnPoint, Quaternion.identity);
            zombie.GetComponent<Zombie>().Initialize(zombieSpeed);
            zombieSpeed += speedIncrement;

            yield return new WaitForSeconds(timeSpawn);
        }
    }
}
