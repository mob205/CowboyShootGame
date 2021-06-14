using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeUpgrade : Upgrade
{
    [SerializeField] float explosionRadius;
    [SerializeField] LayerMask explosionLayers;

    float explosionDamage;
    public override void ApplyUpgrade(int level)
    {
        EnemySpawner.instance.OnEnemyDeath += TriggerExplosion;
        explosionDamage = coefficient * level * FindObjectOfType<GunController>().damage;
    }
    void TriggerExplosion(object sender, Enemy e)
    {
        var hitEnemies = Physics2D.OverlapCircleAll(e.transform.position, explosionRadius, explosionLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().Damage(explosionDamage);
        }
    }
}
