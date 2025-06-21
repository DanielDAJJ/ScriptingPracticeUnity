using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Entity
{
    [SerializeField] private float jumpForce = 10f;
    private float moveInput;
    void Start()
    {
        
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        HandleMovement(new Vector2(moveInput, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal == Vector2.up)
        {
            IsGrounded = true;
            Debug.Log($"valor de IsGrounded playercontroller es: {IsGrounded}");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
        Debug.Log($"valor de IsGrounded playercontroller es: {IsGrounded}");
    }
}
