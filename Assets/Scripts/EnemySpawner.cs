using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public float spawnRadius = 20f;
    private Transform player;
    private bool canSpawn = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player != null)
        {
            InvokeRepeating("SpawnEnemy", 0f, spawnRate);
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }

    void SpawnEnemy()
    {
        if (!canSpawn || player == null)
        {
            return;
        }

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)player.position + randomDirection * spawnRadius;

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}