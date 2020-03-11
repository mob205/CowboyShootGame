using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public const float Left = 0;
    public const float Right = 1;

    [SerializeField] float playerSpeed;

    Camera mainCamera;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessMovement();
        ProcessAnimations();
    }
    void ProcessMovement()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.MovePosition(transform.position + (movement * playerSpeed * Time.deltaTime));
        animator.SetBool("IsMoving", (movement.magnitude > 0));
    }
    void ProcessAnimations()
    {
        
        if (Input.mousePosition.x < mainCamera.WorldToScreenPoint(transform.position).x)
        {
            animator.SetFloat("Direction", Left);
        }
        else
        {
            animator.SetFloat("Direction", Right);
        }
    }
}
