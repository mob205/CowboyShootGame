using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    public float healthMod;
    public float damageMod;
    public float enemySpawnMod;

    public const float healthIncrease = 0.2f;
    public const float damageIncrease = 0.15f;
    public const float enemySpawnIncrease = 0.15f;

    int level = 1;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CalculateValues();
        StartLevel();
    }
    void StartLevel()
    {
        EnemySpawner.instance.StartSpawning();
    }
    void CalculateValues()
    {
        damageMod = damageIncrease * (level - 1) + 1;
        healthMod = healthIncrease * (level - 1) + 1;
        enemySpawnMod = enemySpawnIncrease * (level - 1) + 1;
    }
    public void EndLevel()
    {
        level += 1;
        
    }
    public int GetLevel()
    {
        return level;
    }
    void Update()
    {
        
    }
}
