using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fire : MonoBehaviour
{
    [SerializeField] private float speed;
    private void OnEnable()
    {
        var player = FindObjectOfType<PlayerHealth>().gameObject;
        if (!player.GetComponent<SpriteRenderer>().flipX)
        {
            this.transform.localPosition = player.transform.localPosition + Vector3.right * 0.5f;
            this.GetComponent<Rigidbody2D>().velocity = Vector3.right * speed;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            this.transform.localPosition = player.transform.localPosition + Vector3.left * 0.5f;
            this.GetComponent<Rigidbody2D>().velocity = Vector3.left * speed;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Update()
    {
        var screenPos = Camera.main.WorldToScreenPoint(this.transform.localPosition);
        var onScreen = screenPos.y > 0f && screenPos.y < Screen.height && screenPos.x > 0f && screenPos.x < Screen.width;
        if(!onScreen) this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer is (int)Layer.Enemy or (int)Layer.Ground) this.gameObject.SetActive(false);
    }
}
