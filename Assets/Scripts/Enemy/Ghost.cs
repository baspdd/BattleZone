using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isMovingRight = true;
    private float targetX;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private bool isChasing;
    [SerializeField] private float chaseDistance;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        targetX = transform.position.x + 5f; // Set initial target position
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (isChasing)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                spriteRenderer.flipX = false;
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
                spriteRenderer.flipX = true;
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            if(Vector2.Distance(transform.position,playerTransform.position)<chaseDistance)
            {
                isChasing = true; 
            }
            float step = speed * Time.deltaTime;

            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetX, transform.position.y, transform.position.z), step);

            // Check if the target position is reached
            if (Mathf.Abs(transform.position.x - targetX) < 0.01f)
            {
                // Flip the sprite renderer
                spriteRenderer.flipX = !isMovingRight;

                // Update the target position based on the current direction
                if (isMovingRight)
                    targetX -= 4f; // Move left by 10 units
                else
                    targetX += 4f; // Move right by 10 units

                isMovingRight = !isMovingRight; // Toggle the direction
            }
        }
    }



}
