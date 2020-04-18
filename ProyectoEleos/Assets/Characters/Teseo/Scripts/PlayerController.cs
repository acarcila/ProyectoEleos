using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    [Range(0, .3f)] private float m_MovementSmoothing = 0.05f;
    [SerializeField] private Animator animator;
    public StatsController statsController;
    public float runSpeed;
    public float jumpForce;
    public float coolDownInvincible;
    public GameObject waterBlessingPrefab;
    public Vector2 waterBlessingOffset;
    public GameObject thunderBlessingPrefab;
    public Vector2 thunderBlessingOffset;

    private Rigidbody2D rigidBody;
    private Vector2 m_Velocity = Vector2.zero;
    private float horizontalMove = 0f;
    private bool isGrounded = false;
    private bool isFacingRight = true;
    private bool isInvincible = false;
    private float invincibleTime;
    private int jumpCount;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public override void toStart()
    {
    }

    public override void toUpdate()
    {
        float inputMovement = Input.GetAxisRaw("Horizontal");
        horizontalMove = inputMovement * runSpeed;

        animator.SetFloat("movement", Mathf.Abs(inputMovement));

        if (inputMovement > 0 && !isFacingRight)
        {
            flip();
        }
        else if (inputMovement < 0 && isFacingRight)
        {
            flip();
        }

        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount > 0))
        {
            jump();
        }

        if (Input.GetButtonDown("Attack") && isGrounded)
        {
            attack();
        }

        if (Input.GetButtonDown("WaterBlessing") && isGrounded)
        {
            activateWaterBlessing();
        }

        if (Input.GetButtonDown("ThunderBlessing") && isGrounded)
        {
            activateThunderBlessing();
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

    public override void toFixedUpdate()
    {
        move(horizontalMove * Time.fixedDeltaTime);

    }

    public void setIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;

        if (this.isGrounded)
        {
            this.jumpCount = 2;
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
            animator.SetBool("isLeft", true);

            isFacingRight = false;
        }
        else
        {
            animator.SetBool("isLeft", false);

            isFacingRight = true;
        }
    }

    public void jump()
    {
        rigidBody.velocity = Vector2.Scale(rigidBody.velocity, new Vector2(1, 0));
        rigidBody.AddForce(new Vector2(0f, jumpForce));
        isGrounded = false;
        Debug.Log(jumpCount);
        jumpCount--;

        animator.SetTrigger("isJumping");
    }

    public void attack()
    {
        animator.SetTrigger("attack");
    }

    public void activateWaterBlessing()
    {
        GameObject prefab = Object.Instantiate(waterBlessingPrefab, transform.position, transform.rotation, null);
        if(isFacingRight)
        {
            prefab.transform.Translate(waterBlessingOffset.x, waterBlessingOffset.y, 0);
        }
        else
        {
            prefab.transform.Translate(-waterBlessingOffset.x, waterBlessingOffset.y, 0);
            prefab.transform.localScale = Vector3.Scale(prefab.transform.localScale, new Vector3(-1, 1, 1));
        }

    }

    public void activateThunderBlessing()
    {
        GameObject prefab = Object.Instantiate(thunderBlessingPrefab, transform.position, transform.rotation, null);
        if(isFacingRight)
        {
            prefab.transform.Translate(thunderBlessingOffset.x, thunderBlessingOffset.y, 0);
        }
        else
        {
            prefab.transform.Translate(-thunderBlessingOffset.x, thunderBlessingOffset.y, 0);
            prefab.transform.localScale = Vector3.Scale(prefab.transform.localScale, new Vector3(-1, 1, 1));
        }

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
}
