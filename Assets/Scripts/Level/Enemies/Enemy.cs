using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IDamageable
{
    [Header("General")]
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] LayerMask layerMask;

    [Header("Stats")]
    [SerializeField] float baseHealth;
    [SerializeField] float moveSpeed;
    [SerializeField] public float damage = 10f;

    [Header("Rewards")]
    public int minBaseCoins;
    public int maxBaseCoins;




    Rigidbody2D rb;

    float health;

    virtual protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = baseHealth * LevelManager.instance.healthMod;
        damage *= LevelManager.instance.damageMod;
    }

    virtual protected void FixedUpdate()
    {
        Move();
    }
    virtual protected void Move()
    {
        var direction = (PlayerController.instance.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + (moveSpeed * Time.fixedDeltaTime * direction));
    }
    virtual protected void OnTriggerStay2D(Collider2D collision)
    {
        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            collision.GetComponent<IDamageable>().Damage(damage);
        }
    }
    virtual public void Damage(float damage)
    {
        if (health <= 0) { return; }
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    virtual protected void Die()
    {
        deathParticles.transform.parent = null;
        deathParticles.Play();
        Destroy(deathParticles.gameObject, deathParticles.main.duration);
        Destroy(gameObject);
        EnemySpawner.instance.TriggerEnemyDeath(this);
    }
}
