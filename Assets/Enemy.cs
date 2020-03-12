using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int moveSpeed;

    Rigidbody2D rb;
    Animator anim;
    virtual protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    virtual protected void Update()
    {
        Move();
    }
    virtual protected void Move()
    {
        rb.transform.LookAt(PlayerController.instance.transform);
        rb.MovePosition(transform.position + (transform.forward * moveSpeed * Time.deltaTime));

    }
}
