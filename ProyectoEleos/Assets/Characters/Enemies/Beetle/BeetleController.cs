using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [Range(0, .3f)] private float m_MovementSmoothing = 0.05f;
    [SerializeField] private string playerTag;
    
    private bool isFacingRight = false;
    private Rigidbody2D rigidBody;
    private Vector3 m_Velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move(movementSpeed * Time.deltaTime);
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

        if(isFacingRight)
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == playerTag)
        {
            //hacer daño
        }
    }
}
