using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Reference to the cube prefab
    public List<Transform> spawnPositions; // List of spawn position GameObjects
    public float minSpawnDelay = 2.0f; // Minimum time delay in seconds
    public float maxSpawnDelay = 5.0f; // Maximum time delay in seconds
    public float yOffset = 0.0f; // Y offset to add to the spawn positions

    private float nextSpawnTime;
    private float randomSpawnDelay;

    private void Start()
    {
        // Initialize the first spawn time with a random delay
        SetNextSpawnTime();
    }

    private void Update()
    {
        // Check if it's time to spawn a cube
        if (Time.time >= nextSpawnTime)
        {
            SpawnCube();
            SetNextSpawnTime(); // Set the next spawn time with a random delay
        }
    }

    private void SetNextSpawnTime()
    {
        // Calculate the next spawn time based on the specified range
        randomSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        nextSpawnTime = Time.time + randomSpawnDelay;
    }

    public void SpawnCube()
    {
        if (cubePrefab != null && spawnPositions.Count > 0)
        {
            // Randomly select a spawn position from the list
            int randomIndex = Random.Range(0, spawnPositions.Count);
            Transform selectedSpawnPosition = spawnPositions[randomIndex];

            // Calculate the new spawn position with the Y offset
            Vector3 spawnPositionWithOffset = selectedSpawnPosition.position + new Vector3(0, yOffset, 0);

            // Instantiate the cube prefab at the modified spawn position
            Instantiate(cubePrefab, spawnPositionWithOffset, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Cube prefab or spawn positions are not assigned!");
        }
    }
}