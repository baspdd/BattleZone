using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    public void TakeDamage(int damage){
        currentHealth -=damage;
        playerHealthSlider.value = currentHealth;
        if(currentHealth <= 0){
            return;
        }
    }
}
