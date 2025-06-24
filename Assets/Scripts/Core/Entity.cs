using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SceneManagement;

public class Entity : MonoBehaviour
{
    [Header("Entity Configuration")]
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected int maxHealth = 100;

    protected Rigidbody2D rb;
    protected Animator animator;
    protected int currentHealth;

    [Header("Public properties")]
    public bool IsGrounded { get; protected set; }
    public bool IsAlive => currentHealth > 0; 
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    public void ReciveDamage(int damage)
    {
        if (!IsAlive) return;
        TakeDamage(damage);
        Debug.Log($"{gameObject.name} recibe {damage} de daño. Salud actual: {currentHealth}/{maxHealth}");
    }
    protected virtual void TakeDamage(int damage)
    {
        currentHealth =  Mathf.Max(0, currentHealth - damage);
        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log($"{gameObject.name} ha muerto");
    }
    protected virtual void HandleMovement(Vector2 direction)
    {
        if (!IsAlive) return;

        Vector2 velocity = new Vector2(direction.x * moveSpeed, rb.linearVelocityY);
        rb.linearVelocity = velocity;

        if(direction.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(direction.x), 1, 1);
        }
    }
}
