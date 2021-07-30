using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }
    public void resumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void pauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void loadHomePage()
    {
        Time.timeScale = 1f;
        int sceneOrder = 0;
        SceneManager.LoadScene(sceneOrder);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
