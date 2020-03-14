using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector] public static EnemySpawner instance;

    [SerializeField] BoxCollider2D[] spawnAreas;
    [SerializeField] float minSpawnTime = 0.5f;
    [SerializeField] float maxSpawnTime = 3f;
    [SerializeField] GameObject enemyPrefab;

    int enemyCount;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            
            Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
            enemyCount++;
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
        }
    }
    private Vector2 GetRandomPosition()
    {
        var box = spawnAreas[Random.Range(0, spawnAreas.Length)];
        Vector2 randomPosition = new Vector2(Random.Range(-box.size.x / 2, box.size.x), Random.Range(-box.size.y / 2, box.size.y / 2));
        return (Vector2)box.transform.position + randomPosition;
    }
    public void AlertDeath()
    {
        enemyCount--;
    }
}
