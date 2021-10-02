using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeUpgrade : Upgrade
{
    [SerializeField] float explosionRadius;
    [SerializeField] LayerMask explosionLayers;

    float explosionDamage;
    public override int GetCost(int level)
    {
        return Mathf.FloorToInt(costFactor * Mathf.Pow(2, level));
    }
    public override void ApplyUpgrade(int level)
    {
        EnemySpawner.instance.OnEnemyDeath += TriggerExplosion;
        explosionDamage = coefficient * level * FindObjectOfType<GunController>().damage;
    }
    void TriggerExplosion(object sender, Enemy e)
    {
        var hitEnemies = Physics2D.OverlapCircleAll(e.transform.position, explosionRadius, explosionLayers);
        foreach(Collider2D enemyCol in hitEnemies)
        {
            var enemy = enemyCol.GetComponent<Enemy>();
            if(enemy != null)
                enemy.GetComponent<Enemy>().Damage(explosionDamage);
        }
    }
}
