using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, IDamageable
{
    public static PlayerController instance;

    public const float Left = 0;
    public const float Right = 1;

    [SerializeField] float playerSpeed;
    [SerializeField] public float baseHealth;
    [SerializeField] float invulnTime;

    public float currentHealth;
    bool isInvuln;

    Camera mainCamera;
    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        currentHealth = baseHealth;
    }

    void Update()
    {
        ProcessMovement();
        if(animator != null)
            ProcessAnimations();
    }
    public void Damage(float amount)
    {
        if (isInvuln) { return; }
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            //Implement death sequence here
        }
        HealthBar.instance.SetHealthBar(currentHealth / baseHealth);
        StartCoroutine(ApplyInvulnerability());
    }
    IEnumerator ApplyInvulnerability()
    {
        isInvuln = true;
        yield return new WaitForSeconds(invulnTime);
        isInvuln = false;
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
