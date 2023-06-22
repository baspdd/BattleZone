using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStage : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private float horizontalMove = 0f;
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
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
        if (!isGrounded) setStage(2);

        else
        {
            setStage(0);
            if (horizontalMove != 0 && isGrounded) setStage(1);
        }
    }

    private void Movement()
    {
        var jumpCheck = Input.GetKeyDown(KeyCode.UpArrow);
        if (jumpCheck && isGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0)
        {
            if ((transform.position.x <= -8f && horizontalMove < 0)
           || (transform.position.x >= 8f && horizontalMove > 0)) return;

            if (horizontalMove < 0) spriteRenderer.flipX = true;
            else if (horizontalMove > 0) spriteRenderer.flipX = false;

            Vector3 movement = new Vector3(horizontalMove, 0f, 0f) * speed;
            transform.position += movement * Time.deltaTime;
        }
    }


    private bool isGrounded = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    private void setStage(int stage)
    {
        animator.SetInteger("Stage", stage);
    }
}
