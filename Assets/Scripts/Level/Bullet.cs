using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public GameObject shooter;
    [HideInInspector] public float damage;
    [HideInInspector] public float speed;

    public ParticleSystem onHitParticles;

    void Update()
    {
        Move();
    }
    void Move()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != shooter)
        {
            onHitParticles.transform.parent = null;
            onHitParticles.Play();
            Destroy(onHitParticles.gameObject, onHitParticles.main.duration);
            Destroy(gameObject);
        }
        
    }
}
