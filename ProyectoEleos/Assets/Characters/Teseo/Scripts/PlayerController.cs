using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] private float m_MovementSmoothing = 0.05f;

    float horizontalMove = 0f;
    public float runSpeed = 40f;

    public float jumpForce;
    private bool isGrounded = false;
    
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime);
       
    }

    public void setIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }

    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, rigidBody.velocity.y);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

}
