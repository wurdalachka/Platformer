using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rigidbody2D; 
    public float speed = 10;
    public float jumpForce = 10;
    private bool canJump = true;
    public float maxSpeed = 5;
    public float stoppingForce = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

      rigidbody2D = GetComponent<Rigidbody2D>();
     
    }

    // Update is called once per frame
    private void FixedUpdate()

    { 
      HandlePlayerXMovement();
      MaxSpeedLimitng();
    }
    
    private void HandlePlayerXMovement()
    {
       
        if (direction.x != 0)
        {
            rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
        }

        else if (rigidbody2D.linearVelocityX !=0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * speed, 0));
        }
    }

    private void MaxSpeedLimitng()
        {
      

            if (rigidbody2D.linearVelocityX >= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }
        else if(rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }

        }
    }

    
    private void OnMove(InputValue value)
{
    {
                //Debug.Log("Move");
                //Debug.Log(value.Get<Vector2>());
                direction = value.Get<Vector2>();

    }
}

private void OnJump()
    {
        if(canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

      canJump = true;

    }

}





