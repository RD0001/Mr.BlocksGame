using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float speed;
    public float initialSpeed;
    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Get player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 currentDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        if (currentDirection == Vector3.zero || Input.GetKey(KeyCode.Space))
        {
            speed = initialSpeed;
            rigidbody2d.velocity = new Vector2(0f, 0f);
            currentDirection = Vector3.zero;
        }
        else
        {
            speed += acceleration * Time.deltaTime;
            if (horizontalInput > 0)
            {
                rigidbody2d.velocity = new Vector2(speed, 0f);
            }
            else if (horizontalInput < 0)
            {
                rigidbody2d.velocity = new Vector2(-speed, 0f);
            }
            else if (verticalInput > 0f)
            {
                rigidbody2d.velocity = new Vector2(0f, speed);
            }
            else if (verticalInput < 0)
            {
                rigidbody2d.velocity = new Vector2(0f, -speed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Door")
        {
            Debug.Log("Level completed");
        }
    }
}
