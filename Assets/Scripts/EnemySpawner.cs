using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector] public static EnemySpawner instance;

    [SerializeField] BoxCollider2D[] spawnAreas;
    [SerializeField] float minSpawnTime = 0.5f;
    [SerializeField] float maxSpawnTime = 3f;
    [SerializeField] int maxEnemies = 10;
    [SerializeField] float defaultEnemyAmount = 15;
    [SerializeField] GameObject enemyPrefab;

    int currentEnemyCount;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies(defaultEnemyAmount * LevelManager.instance.enemySpawnMod));
    }
    IEnumerator SpawnEnemies(float amount)
    {
        var enemiesSpawned = 0;
        while (true)
        {
            if(currentEnemyCount < maxEnemies && enemiesSpawned < amount)
            {
                Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
                currentEnemyCount++;
                enemiesSpawned++;
            }
            if(enemiesSpawned >= amount && currentEnemyCount == 0)
            {
                LevelManager.instance.EndLevel();
                break;
            }
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
    private Vector2 GetRandomPosition()
    {
        var box = spawnAreas[Random.Range(0, spawnAreas.Length)];
        Vector2 randomPosition = new Vector2(Random.Range(-box.size.x / 2, box.size.x), Random.Range(-box.size.y / 2, box.size.y / 2));
        return (Vector2)box.transform.position + randomPosition;
    }
    public void OnEnemyDeath()
    {
        currentEnemyCount--;
    }
}
