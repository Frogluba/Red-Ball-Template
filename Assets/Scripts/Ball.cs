using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float jumpSpeed = 10;
    public float maxSpeed = 10;
    public float moveForce = 1;
    Rigidbody2D rb;
    public bool isGrounded;
    //public GameObject ballParticle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(hor, 0);
        rb.AddForce(new Vector2(hor * moveForce * Time.deltaTime, 0));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        LimitSpeed();
    }

    void LimitSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.drag = 1;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void Jump()
    {
        rb.velocity += Vector2.up * jumpSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;

        if (other.gameObject.tag == "Enemy")
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.instance.Lose();
        Destroy(gameObject);
        // destroy into pieces
        //for (int i = 0; i < 10; i++)
       // {
           // var offset = Random.insideUnitSphere;
            //Instantiate(ballParticle, transform.position + offset, transform.rotation);
       // }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Checkpoint")
        {
            GameManager.instance.Win();
        }
    }

}
