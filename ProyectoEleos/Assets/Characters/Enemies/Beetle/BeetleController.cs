using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleController : CharacterController
{
    [SerializeField] private float movementSpeed;
    [Range(0, .3f)] private float m_MovementSmoothing = 0.05f;
    [SerializeField] private string playerTag;
    public PlayerController playerController;
    public StatsController statsController;
    public float coolDownInvincible;

    private bool isFacingRight = false;
    private Rigidbody2D rigidBody;
    private Vector3 m_Velocity = Vector3.zero;
    private bool isInvincible = false;
    private float invincibleTime;

    public override void toStart()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public override void toUpdate()
    {
        if (isInvincible)
        {
            invincibleTime -= Time.deltaTime;

            if (invincibleTime <= 0)
            {
                isInvincible = false;
            }
        }
    }

    public override void toFixedUpdate()
    {
        move(movementSpeed * Time.deltaTime);
    }

    public override void takeDamage(int damage)
    {
        if (!isInvincible)
        {
            statsController.decreaseHealth(damage);
            isInvincible = true;
            invincibleTime = coolDownInvincible;
        }
    }

    public bool getIsFacingRight()
    {
        return this.isFacingRight;
    }

    public void setIsFacingRight(bool isFacingRight)
    {
        this.isFacingRight = isFacingRight;
    }

    public void move(float move)
    {
        Vector3 targetVelocity = new Vector3();

        if (isFacingRight)
        {
            targetVelocity = new Vector2(move * 10f, rigidBody.velocity.y);
        }
        else
        {
            targetVelocity = new Vector2(-move * 10f, rigidBody.velocity.y);
        }

        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    public void flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 desiredScale = gameObject.transform.localScale;
        desiredScale.x *= -1;

        gameObject.transform.localScale = desiredScale;
    }
}
