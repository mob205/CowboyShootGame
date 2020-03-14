using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [Header("General")]
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] LayerMask explosionLayers;

    [Header("Stats")]
    [SerializeField] float baseHealth;
    [SerializeField] float moveSpeed;
    [SerializeField] float deathExplosionRadius;
    [SerializeField] float explosionDamage = 10;
    [SerializeField] public float damage = 10f;



    const float Left = 0;
    const float Right = 1;

    Rigidbody2D rb;
    Animator anim;

    float health;

    virtual protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = baseHealth * LevelManager.instance.healthMod;
        damage *= LevelManager.instance.damageMod;
    }

    virtual protected void Update()
    {
        Move();
    }
    virtual protected void Move()
    {
        var direction = (PlayerController.instance.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
        
        if(PlayerController.instance.transform.position.x < transform.position.x)
        {
            anim.SetFloat("Direction", Left);
        }
        else
        {
            anim.SetFloat("Direction", Right);
        }
    }
    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            var bullet = collision.GetComponent<Bullet>();
            Damage(bullet.damage);
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
        //var hitEnemies = Physics2D.OverlapCircleAll(transform.position, deathExplosionRadius, explosionLayers);
        //foreach(Collider2D enemy in hitEnemies)
        //{
        //    enemy.GetComponent<Enemy>().Damage(explosionDamage);
        //}

        EnemySpawner.instance.OnEnemyDeath();
        deathParticles.transform.parent = null;
        deathParticles.Play();
        Destroy(deathParticles.gameObject, deathParticles.main.duration);
        Destroy(gameObject);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, deathExplosionRadius);
    //}
}
