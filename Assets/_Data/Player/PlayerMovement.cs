using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool isFacingRight = false;
    private bool isGrounded;


    [Header("Movement Settings")]
    public float moveSpeed;
    public float jumpForce = 10f;
    private float moveInputDirection;

    private Animator anim;
    private Rigidbody2D rb;
    private int facingDirection = 1;

    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        anim = transform.parent.GetComponent<Animator>();
    }

    private void Update()
    {
        this.CheckInput();
    }

    private void FixedUpdate()
    {
        this.ApplyMovement();
    }

    protected virtual void CheckInput()
    {
        moveInputDirection = Input.GetAxis("Horizontal");
        Flip();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            this.Jump();
            this.isGrounded = false;
            anim.SetBool("isJumping", !isGrounded);
        }
    }

    protected virtual void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    protected virtual void ApplyMovement()
    {
        rb.velocity = new Vector2(moveSpeed * moveInputDirection, rb.velocity.y);
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("yVelocity", (rb.velocity.y));
    }

    public virtual void Flip()
    {
        if (isFacingRight && moveInputDirection > 0f || !isFacingRight && moveInputDirection < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.parent.localScale;
            ls.x *= -1f;
            transform.parent.localScale = ls;
        }
    }
    public int GetFacingDirection()
    {
        return facingDirection;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        this.isGrounded = true;
        anim.SetBool("isJumping", !isGrounded);
    }
}
