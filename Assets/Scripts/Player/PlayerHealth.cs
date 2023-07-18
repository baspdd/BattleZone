using Codice.Client.Common;
using Cysharp.Threading.Tasks;
using System;
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
    [SerializeField] private GameObject gameOverUI;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = maxHealth;
        gameOverUI.SetActive(false);
    }

    public async void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            PlayHurtSound();
        }
        currentHealth -= damage;
        playerHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            onHitSE.Stop();
            DeathSE.Play();
            gameOver();
        }
    }

    private void gameOver()
    {
        gameOverUI.SetActive(true);
        UnityEngine.Time.timeScale = 0;
        //AudioListener.pause = false;
    }

    public void PlayHurtSound()
    {
        if (onHitSE.isPlaying)
        {
            onHitSE.Stop();
        }

        onHitSE.Play();
    }

    public void Restart()
    {
        //gameOverUI.SetActive(false);
        UnityEngine.Time.timeScale = 1;
        AudioListener.pause = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
