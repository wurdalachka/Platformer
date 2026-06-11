using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermotor : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rigidbody2d;
    Animator animator;
    private float lastDirection = 1f;
    public float speed = 10;
    public float jumpforce = 5;
    public float maxspeed = 5;
    public float stoppingforce = 7;
    public float dashForce = 20;
    private bool canDash = true;
    public LayerMask groundLayer;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
        MaxSpeedLimiting();
        UpdateAnimations();
    }

    private bool IsGrounded()
    {
    return Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.8f), 0.5f);
    }

    private void UpdateAnimations()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(rigidbody2d.linearVelocityX));
        animator.SetFloat("yVelocity", rigidbody2d.linearVelocityY);
        animator.SetBool("isJumping", !IsGrounded());

        if (direction.x != 0)
            lastDirection = -Mathf.Sign(direction.x);

        transform.localScale = new Vector3(lastDirection * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    private void HandlePlayerMovement()
    {
        if (direction.x != 0)
        {
            rigidbody2d.AddForce(new Vector2(direction.x * speed, 0));
        }
        else if (rigidbody2d.linearVelocityX != 0)
        {
            rigidbody2d.AddForce(new Vector2(-rigidbody2d.linearVelocityX * stoppingforce, 0));
        }
    }

    private void MaxSpeedLimiting()
    {
        if (!canDash) return;

        if (rigidbody2d.linearVelocityX >= maxspeed)
            rigidbody2d.linearVelocityX = maxspeed;
        else if (rigidbody2d.linearVelocityX <= -maxspeed)
            rigidbody2d.linearVelocityX = -maxspeed;
    }

    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnDash()
    {
        if (canDash)
        {
            if (direction.x != 0)
                rigidbody2d.AddForce(new Vector2(direction.x * dashForce, 0), ForceMode2D.Impulse);
            else
                rigidbody2d.AddForce(new Vector2(dashForce, 0), ForceMode2D.Impulse);

            canDash = false;
            StartCoroutine(ResetDash(1));
        }
    }

    IEnumerator ResetDash(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canDash = true;
    }

    private void OnJump()
    {
        if (IsGrounded())
        {
            rigidbody2d.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }

}


