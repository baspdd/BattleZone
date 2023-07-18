using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMeet : MonoBehaviour
{
    public AudioSource VillagerSE;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player )
        {
            VillagerSE.Play();

        }
    }
}
