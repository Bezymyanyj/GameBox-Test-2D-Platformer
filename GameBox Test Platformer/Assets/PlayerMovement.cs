using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;
    public float jumpForce = 200f;
    public LayerMask groundMask;

    private Rigidbody2D rb;

    private float horizontalInput;
    private Vector2 moveCharacter;

    private bool jump;
    private bool isMoving;
    private bool isGrounded;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.IsTouchingLayers(GetComponent<CircleCollider2D>(), groundMask);
        
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            isMoving = true;

        }

        //Debug.Log(horizontalMove);

        if (Input.GetButtonDown("Jump") & isGrounded)
        {
            jump = true;
        }

        moveCharacter.x += horizontalInput;
        
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.AddForce(Vector2.right * horizontalInput * speed * Time.fixedDeltaTime, ForceMode2D.Force);
            isMoving = false;
        }
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            jump = false;
        }
        //rb.velocity = newLog;
    }
}
