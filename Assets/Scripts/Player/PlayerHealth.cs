using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int currentHealth;
    public static bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        isDead = currentHealth <= 0;
        if (isDead)
        {
            if (audioSource && deathSound)
            {
                audioSource.PlayOneShot(deathSound);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
