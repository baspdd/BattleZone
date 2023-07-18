using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationStage : MonoBehaviour
{
    [Header("JumpSystem")]
    [SerializeField] float jumpTime;
    [SerializeField] float jumpMutiplier;
    [SerializeField] private float jumpPower = 1f;
    [SerializeField] private float fallMutiplier;
    [SerializeField] private float speed = 5f;

    private float horizontalMove = 0f;
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    Vector2 vecGravity;

    bool isJumping;
    float jumpCounter;
    void Start()
    {
        vecGravity = new Vector2 (0f, -Physics2D.gravity.y);
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        stageAnimation();
    }

    private void stageAnimation()
    { 
        if (beAttacked) setStage(3);
        else if (!isGrounded) setStage(2);
        else if (horizontalMove != 0 && isGrounded) setStage(1);
        else setStage(0);
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
        }

        if(rigidbody2D.velocity.y>0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if(jumpCounter > jumpTime) isJumping = false;

            float t= jumpCounter / jumpTime;
            float currentJumpMuti = jumpMutiplier;

            if(t > 0.5f)
            {
                currentJumpMuti = currentJumpMuti * (1 - t);
            }
            
            rigidbody2D.velocity += vecGravity * currentJumpMuti * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
            jumpCounter = 0;

            if(rigidbody2D.velocity.y>0)
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y * 0.6f);
            }
        }

        if (rigidbody2D.velocity.y < 0)
        {
            rigidbody2D.velocity -= vecGravity * fallMutiplier * Time.deltaTime;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0)
        {
            if (horizontalMove < 0) spriteRenderer.flipX = true;
            else if (horizontalMove > 0) spriteRenderer.flipX = false;

            Vector3 movement = new Vector3(horizontalMove, 0f, 0f) * speed;
            transform.position += movement * Time.deltaTime;
        }
    }


    private bool isGrounded = false;
    private bool beAttacked = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) beAttacked = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) beAttacked = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = false;
    }

    public void setStage(int stage)
    {
        animator.SetInteger("Stage", stage);
    }
}
