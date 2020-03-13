using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] float baseHealth;
    [SerializeField] float moveSpeed;

    const float Left = 0;
    const float Right = 1;

    Rigidbody2D rb;
    Animator anim;

    float health;

    virtual protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = baseHealth;
    }

    virtual protected void Update()
    {
        Move();
    }
    virtual protected void Move()
    {
        rb.MovePosition(Vector2.Lerp(transform.position, PlayerController.instance.transform.position, moveSpeed * Time.deltaTime));
        
        if(PlayerController.instance.transform.position.x < transform.position.x)
        {
            anim.SetFloat("Direction", Left);
        }
        else
        {
            anim.SetFloat("Direction", Right);
        }
    }
}
