using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public GameObject shooter;
    [HideInInspector] public float damage;
    [HideInInspector] public float speed;

    [SerializeField] LayerMask layerMask;

    public ParticleSystem onHitParticles;

    IDamaging damager;
    bool hasDamaged;
    private void Start()
    {
        damager = shooter.GetComponent<IDamaging>();
    }
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
        if (collision.gameObject != shooter && layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            if (damager != null)
            {
                damager.OnDamageDealt(this, damage);
            }
            //collision.gameObject.GetComponent<IDamageable>().Damage(damage);
            if (collision.isTrigger && !hasDamaged)
            {
                collision.gameObject.GetComponentInParent<IDamageable>().Damage(damage);
                hasDamaged = true;
                Debug.Log($"Damaging {collision.gameObject.name}");
            }
            Destroy(gameObject);
            onHitParticles.transform.parent = null;
            onHitParticles.Play();
            Destroy(onHitParticles.gameObject, onHitParticles.main.duration);
            
        }
        
    }
}
