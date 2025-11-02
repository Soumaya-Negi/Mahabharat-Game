using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public float spawnInterval = 3f;
    public int maxEnemies = 10;

    public int enemiesSpawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(spawnEnemy), 0f, spawnInterval);
    }
    void spawnEnemy()
    {
        if (enemiesSpawned >= maxEnemies) return;
            
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(enemyPrefab, spawnPoint.position , Quaternion.identity);   
        enemiesSpawned++;

    }
}