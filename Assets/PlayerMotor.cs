using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class playermotor : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rigidbody2d;
    public float speed = 10;
    public float jumpforce = 5;
    public float dashforce = 15;
    public float maxspeed = 5;
    public float stoppingforce = 7;
    private bool canJump = true;
    private bool canDash = true;
    private Animator animator;
    private float initScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initScale = transform.localScale.x;
    }
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        animator.SetFloat("yVelocity", rigidbody2d.linearVelocityY);
        animator.SetFloat("xVelocity", Mathf.Abs(rigidbody2d.linearVelocityX));
        //(check if moving right)
       if (direction.x > 0)
       {
    transform.localScale = new Vector3(-initScale, transform.localScale.y, transform.localScale.z);
       }
       else if (direction.x < 0)
       {
    transform.localScale = new Vector3(initScale, transform.localScale.y, transform.localScale.z);
       }
        HandlePlayerMovement();
        MaxSpeedLimiting();
    }
    private void HandlePlayerMovement()
    {
        if (direction.x != 0)
        {
            rigidbody2d.AddForce(new Vector2(direction.x * speed, 0));

        }
        else if (rigidbody2d.linearVelocityX != 0)
        {
            //zatrzymywanie
            rigidbody2d.AddForce(new Vector2(-rigidbody2d.linearVelocityX * stoppingforce, 0));
            
        }
    }
    private void MaxSpeedLimiting()

    {
        if (!canDash)
        {
            return;
        }
        if (rigidbody2d.linearVelocityX >= maxspeed)
        {
            rigidbody2d.linearVelocityX = maxspeed;
        }

        else if (rigidbody2d.linearVelocityX <= -maxspeed)
        {
            rigidbody2d.linearVelocityX = -maxspeed;
        }
        //transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed;
    }
    void OnMove(InputValue value)
    {
        // Debug.Log("Move");
        //Debug.Log(value.Get<Vector2>());
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
    if (canJump)
    {
        rigidbody2d.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        animator.SetBool("isJumping", true);
        canJump = false;
    }
    }
    private void OnDash()
    {
        if (canDash)
        {
            if (direction.x != 0)
            {


                rigidbody2d.AddForce(new Vector2(direction.x * dashforce, 0), ForceMode2D.Impulse);
                animator.SetBool("IsDashing", true);

            }
            else
            {
                rigidbody2d.AddForce(new Vector2(dashforce, 0), ForceMode2D.Impulse);
                animator.SetBool("IsDashing", true);
            }
            canDash = false;
            
            StartCoroutine(ResetDash(1));
        }
    }
    IEnumerator ResetDash(float cooldown)
    {

        yield return new WaitForSeconds(cooldown);      
        canDash = true;
        animator.SetBool("IsDashing", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        animator.SetBool("isJumping", false);
        
    }

     
}


