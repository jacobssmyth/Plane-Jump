using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnRate = 2.0f;
    public float spawnOffset = 2.0f; // Distance off-screen to the right
    public float spawnAreaWidth = 10.0f;
    public float spawnYPosition = 8.0f; // Base Y position where clouds will spawn
    public float spawnYRange = 2.0f; // Range of random Y values

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCloud();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnCloud()
    {
        float cameraRightX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float randomX = Random.Range(cameraRightX + spawnOffset, cameraRightX + spawnOffset + spawnAreaWidth);
        float randomY = Random.Range(spawnYPosition - spawnYRange / 2, spawnYPosition + spawnYRange / 2); // Random Y within a range
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
        Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
    }
}
