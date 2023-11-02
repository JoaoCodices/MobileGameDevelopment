using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.SocialPlatforms.Impl;

public class CoinsSpawner : MonoBehaviour
{
    public GameObject coinsPrefab; // Reference to the cube prefab
    public List<Transform> spawnPositions; // List of spawn position GameObjects
    public float minSpawnDelay = 2.0f; // Minimum time delay in seconds
    public float maxSpawnDelay = 5.0f; // Maximum time delay in seconds
    public float yOffset = 0.0f; // Y offset to add to the spawn positions

    private float nextSpawnTime;
    private float randomSpawnDelay;


    public TMP_Text coinsText;
    public int Coins = 0;

    private void Start()
    {
        coinsText.text = "Coins: " + Mathf.RoundToInt(Coins).ToString();
        // Initialize the first spawn time with a random delay
        SetNextSpawnTime();
    }

    private void Update()
    {
        coinsText.text = "Coins: " + Mathf.RoundToInt(Coins).ToString();
        // Check if it's time to spawn a cube
        if (Time.time >= nextSpawnTime)
        {
            SpawnCoins();
            SetNextSpawnTime(); // Set the next spawn time with a random delay
        }
        if (transform.position.y < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void SetNextSpawnTime()
    {
        // Calculate the next spawn time based on the specified range
        randomSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        nextSpawnTime = Time.time + randomSpawnDelay;
    }

    public void SpawnCoins()
    {
        if (coinsPrefab != null && spawnPositions.Count > 0)
        {
            // Randomly select a spawn position from the list
            int randomIndex = Random.Range(0, spawnPositions.Count);
            Transform selectedSpawnPosition = spawnPositions[randomIndex];

            // Calculate the new spawn position with the Y offset
            Vector3 spawnPositionWithOffset = selectedSpawnPosition.position + new Vector3(0, yOffset, 0);

            // Instantiate the cube prefab at the modified spawn position
            Instantiate(coinsPrefab, spawnPositionWithOffset, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Coins prefab or spawn positions are not assigned!");
        }
    }
}