using UnityEngine;
using UnityEngine.InputSystem;

public class playermotor : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rigidbody2d;
    public float speed = 10;
    public float jumpforce = 5;
    public float maxspeed = 5;
    public float stoppingforce = 7;
    private bool canJump = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
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
        Debug.Log("Move");
        //Debug.Log(value.Get<Vector2>());
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2d.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            canJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}




