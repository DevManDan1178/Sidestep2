using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public float defaultTimescale = 1f;

    void Start()
    {
        Time.timeScale = defaultTimescale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                pauseMenuUI.SetActive(false);
               Time.timeScale = defaultTimescale;
                GameIsPaused = false;
            }
            else
            {
                Pause();
                pauseMenuUI.SetActive(true);
                 Time.timeScale = 0f;
                GameIsPaused = true;
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = defaultTimescale;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Resume();
        Time.timeScale = 1f;

        SceneManager.LoadScene("Intro");     
    }

    public void QuitGame()
    {
        //Application.Quit();
    }
}

