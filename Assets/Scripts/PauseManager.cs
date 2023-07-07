using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        isGamePaused = true;
        menu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        isGamePaused = false;
        menu.SetActive(false);
    }
}
