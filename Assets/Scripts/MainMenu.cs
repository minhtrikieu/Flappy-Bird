using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public void PlayGame()
    {
        int orderScene = 2;
        SceneManager.LoadScene(orderScene);
    }
   public void PlayMultiplayerGame()
    {
        int orderScene = 4;
        SceneManager.LoadScene(orderScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlaySettings()
    {
        int orderScene = 1;
        SceneManager.LoadScene(orderScene);
    }
}   
