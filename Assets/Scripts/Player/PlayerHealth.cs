using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int currentHealth;
    [SerializeField] private AudioSource onHitSE;
    [SerializeField] private AudioSource DeathSE;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
    }

    public void TakeDamage(int damage){
        if (damage > 0)
        {
            PlayHurtSound();
        }
        currentHealth -=damage;
        playerHealthSlider.value = currentHealth;
        if(currentHealth <= 0){
            onHitSE.Stop();
            DeathSE.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlayHurtSound()
    {
        if (onHitSE.isPlaying)
        {
            onHitSE.Stop();
        }

        onHitSE.Play();
    }
}
