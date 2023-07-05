using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_up : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player"){
            var healthComponent = other.GetComponent<PlayerHealth>();
            if(healthComponent !=null){
                healthComponent.takeDamage(1);
            }
        }
    }
}
