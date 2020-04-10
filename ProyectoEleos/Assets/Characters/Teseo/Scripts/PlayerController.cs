using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, .3f)] private float m_MovementSmoothing = 0.05f;
    [SerializeField] private Animator animator;
    [SerializeField] private RuntimeAnimatorController animatorController;
    [SerializeField] private RuntimeAnimatorController animatorControllerLeft;

    private Rigidbody2D rigidBody;
    private Vector2 m_Velocity = Vector2.zero;

    float horizontalMove = 0f;
    public float runSpeed = 40f;

    public float jumpForce;
    private bool isGrounded = false;
    private bool isFacingRight = true;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float inputMovement = Input.GetAxisRaw("Horizontal");
        horizontalMove = inputMovement * runSpeed;

        if (inputMovement > 0 && !isFacingRight)
        {
            Debug.Log("girar derecha");
            flip();
        }
        else if (inputMovement < 0 && isFacingRight)
        {
            Debug.Log("girar izquierda");
            flip();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump();
        }
    }

    private void FixedUpdate()
    {
        move(horizontalMove * Time.fixedDeltaTime);

    }

    public void setIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
        if(this.isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }
    }

    public void move(float move)
    {
        Vector2 targetVelocity = new Vector2(move * 10f, rigidBody.velocity.y);
        rigidBody.velocity = Vector2.SmoothDamp(rigidBody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    public void flip()
    {
        if (isFacingRight)
        {
            animator.runtimeAnimatorController = animatorControllerLeft;

            isFacingRight = false;
        }
        else
        {
            animator.runtimeAnimatorController = animatorController;

            isFacingRight = true;
        }
    }

    public void jump()
    {
        rigidBody.AddForce(new Vector2(0f, jumpForce));
        isGrounded = false;

        animator.SetTrigger("isJumping");
    }

}
