using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float jumpSpeed;
    public float moveForce;
    Rigidbody2D rb;
    public float maxSpeed;
    bool isGrounded;
    public AudioClip jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(hor, 0) * moveForce);
     //jump
     if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            rb.velocity += Vector2.up * jumpSpeed;
            var source = GetComponent<AudioSource>();
            source.clip = jumpSound;
            source.Play();

        }

        
     //limit speed
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.drag = 1;
        }
        else
        {
            rb.drag = 0;
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;


        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.Lose();
            Destroy(gameObject);
        }
    }

   void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.Win();
    }

}
