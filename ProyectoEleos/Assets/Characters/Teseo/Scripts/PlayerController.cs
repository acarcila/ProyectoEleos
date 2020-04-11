﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, .3f)] private float m_MovementSmoothing = 0.05f;
    [SerializeField] private Animator animator;
    [SerializeField] private RuntimeAnimatorController animatorController;
    [SerializeField] private RuntimeAnimatorController animatorControllerLeft;
    public StatsController statsController;
    public float runSpeed;
    public float jumpForce;
    public float coolDownInvincible;

    private Rigidbody2D rigidBody;
    private Vector2 m_Velocity = Vector2.zero;
    private float horizontalMove = 0f;
    private bool isGrounded = false;
    private bool isFacingRight = true;
    private bool isInvincible = false;
    private float invincibleTime;
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

        if (isInvincible)
        {
            invincibleTime -= Time.deltaTime;

            if (invincibleTime <= 0)
            {
                isInvincible = false;
            }
        }
    }

    private void FixedUpdate()
    {
        move(horizontalMove * Time.fixedDeltaTime);

    }

    public void setIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
        if (this.isGrounded)
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

    public void takeDamage(int damage)
    {
        if (!isInvincible)
        {
            statsController.decreaseHealth(damage);
            isInvincible = true;
            invincibleTime = coolDownInvincible;
        }

    }
}
