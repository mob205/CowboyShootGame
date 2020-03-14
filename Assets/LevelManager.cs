using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    public float healthMod = 1;
    public float damageMod = 1;
    public float enemySpawnMod = 1;

    public const float healthIncrease = 0.2f;
    public const float damageIncrease = 0;

    int level;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }
    float CalculateValue(float difference)
    {
        return difference * (level - 1) + 1;
    }
    void Update()
    {
        
    }
}
