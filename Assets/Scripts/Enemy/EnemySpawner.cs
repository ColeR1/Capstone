using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int maxEnemies = 10; // Set your maximum enemy count here
    public float spawnRadius = 2f; // Set a minimum distance between enemies

    private int spawnedEnemies = 0;
    private float timeSinceLastSpawn = 0f;

    private void Update()
    {
        // Count time since the last enemy was spawned
        timeSinceLastSpawn += Time.deltaTime;

        // Check if it's time to spawn a new enemy, if the maximum count hasn't been reached,
        // and if there's no other enemy within the spawnRadius
        if (timeSinceLastSpawn >= spawnInterval && spawnedEnemies < maxEnemies && !IsSpawnPointOccupied())
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f; // Reset the timer
        }
    }

    private void SpawnEnemy()
    {
        // Generate a random position within the spawn radius
        Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        randomPosition.y = transform.position.y; // Ensure enemies spawn at the same height as the spawner

        // Instantiate a new enemy at the random position
        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, transform.rotation);

        // Increment the spawned enemy count
        spawnedEnemies++;

    }

    private bool IsSpawnPointOccupied()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, spawnRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy")) // Adjust the tag to match your enemy objects
            {
                return true; // Another enemy is within the spawnRadius
            }
        }

        return false; // No enemy is within the spawnRadius
    }

    private void DecrementEnemyCount()
    {
        spawnedEnemies--;
    }
}
