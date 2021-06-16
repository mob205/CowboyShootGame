using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector] public static EnemySpawner instance;

    [SerializeField] BoxCollider2D[] spawnAreas;
    [SerializeField] float minSpawnTime = 0.5f;
    [SerializeField] float maxSpawnTime = 3f;
    [SerializeField] int maxEnemies = 10;
    [SerializeField] float defaultEnemyAmount = 15;
    [SerializeField] EnemyMeta[] enemies;

    int currentEnemyCount;
    int totalEnemyWeight;
    List<EnemyMeta> spawnableEnemies = new List<EnemyMeta>();

    public event EventHandler<Enemy> OnEnemyDeath;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        foreach (var enemyMeta in enemies)
        {
            if (LevelManager.instance.GetLevel() >= enemyMeta.firstLevelAppears)
            {
                totalEnemyWeight += enemyMeta.spawnWeight;
                spawnableEnemies.Add(enemyMeta);
            }
        }
        StartSpawning();
    }
    private Enemy GetEnemySpawn()
    {
        var random = Mathf.Floor(Random.Range(0, totalEnemyWeight));
        var counter = totalEnemyWeight;

        for (var i = 0; i < spawnableEnemies.Count; i++)
        {
            counter -= spawnableEnemies[i].spawnWeight;
            if(random >= counter)
            {
                return spawnableEnemies[i].enemy;
            }
        }
        Debug.Log("No enemy spawn found.");
        return null;
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies(defaultEnemyAmount + LevelManager.instance.enemyPerLevelMod));
    }
    IEnumerator SpawnEnemies(float amount)
    {
        var enemiesSpawned = 0;
        while (true)
        {
            if(currentEnemyCount < (maxEnemies * LevelManager.instance.maxEnemySpawnMod) && enemiesSpawned < amount)
            {
                Instantiate(GetEnemySpawn(), GetRandomPosition(), Quaternion.identity);
                currentEnemyCount++;
                enemiesSpawned++;
            }
            if(enemiesSpawned >= amount && currentEnemyCount == 0)
            {
                StartCoroutine(LevelManager.instance.EndLevel());
                break;
            }
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
    private Vector2 GetRandomPosition()
    {
        var box = spawnAreas[Random.Range(0, spawnAreas.Length)];
        Vector2 randomPosition = new Vector2(Random.Range(-box.size.x / 2, box.size.x / 2), Random.Range(-box.size.y / 2, box.size.y / 2));
        return (Vector2)box.transform.position + randomPosition;
    }
    public void TriggerEnemyDeath(Enemy e)
    {
        currentEnemyCount--;
        OnEnemyDeath?.Invoke(this, e);
    }
}
