using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinReward : MonoBehaviour
{
    void Start()
    {
        EnemySpawner.instance.OnEnemyDeath += RewardCoins;
    }
    void RewardCoins(object sender, Enemy e)
    {
        CoinCounter.AddCoins(Random.Range(e.minBaseCoins, e.maxBaseCoins));
    }
}
