using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
