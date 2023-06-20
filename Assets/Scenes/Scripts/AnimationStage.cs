using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStage : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = 0f;
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0)
        {
            setStage(true, 1);
        }
    }

    private void setStage(bool active, int stage)
    {
        stage = active ? stage : 0;
        animator.SetInteger("Stage", stage);
    }
}
