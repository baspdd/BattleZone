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
        Move();
    }


    private void Jump()
    {
        var jumpCheck = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space);
        setStage(jumpCheck, 2);
        if (jumpCheck)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if ((transform.position.x <= -8f && horizontalMove < 0)
            || (transform.position.x >= 8f && horizontalMove > 0)) return;

        if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        } else if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
        }
        Vector3 movement = new Vector3(horizontalMove, 0f, 0f) * speed;
        transform.position += movement * Time.deltaTime;
        setStage(horizontalMove != 0, 1);
    }

    bool isFacingRight = false;
    void flip()
    {
        if (isFacingRight && horizontalMove < 0 || !isFacingRight && horizontalMove > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 size = transform.localScale;
            size.x = size.x * -1;
            transform.localScale = size;
        }
    }

    private void setStage(bool active, int stage)
    {
        stage = active ? stage : 0;
        animator.SetInteger("Stage", stage);
    }
}
