using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using System.Linq;
public class GameControlMultiplayer : MonoBehaviour
{
    public static GameControlMultiplayer instance;            //A reference to our game control script so we can access it statically.
    public Text playerOneText;                        //A reference to the UI text component that displays the player's score.
    public GameObject gameOvertext;                //A reference to the object that displays the text which appears when the player dies.

    public GameObject player1Controller;
    public GameObject player2Controller;
    public GameObject controller;

    public Text playerTwoText;

    private int count = 0;
    private int score = 0;                        //The player's score.

    public bool gameOver = false;                //Is the game over?
    public float scrollSpeed = -1.5f;
    public AudioSource audioGameOver;

    void Awake()
    {

            //If we don't currently have a game control...
        if (instance == null)
        {
            
                player1Controller.SetActive(false);
                player2Controller.SetActive(false);
                controller.SetActive(false);
                //...set this one to be it...
                instance = this;
           }
            //...otherwise...
            else if (instance != this)
            {
                //...destroy this one because it is a duplicate.
                Destroy(gameObject);
            }
        
    }

    void Update()
    {
        //If the game is over and the player has pressed some input...
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
    public void BirdDiedMulti()
    {

        count++;
        Debug.Log("Collision " + count + " is recorded.");
        if (count == 2)
        {
            controller.SetActive(true);
            gameOvertext.SetActive(true);
            //Set the game to be over.
            gameOver = true;
            
            audioGameOver = GetComponent<AudioSource>();
            audioGameOver.Play(0);
            count = 0;
          
        }

    }

    public void PLayerOneScored()
    {
        //Debug.Log("123");
        //The bird can't score if the game is over.
        if (gameOver)
            return;
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        playerOneText.text = "Player 1: " + score.ToString();
    }

    public void PLayerTwoScored()
    {
        //Debug.Log("123");
        //The bird can't score if the game is over.
        if (gameOver)
            return;
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        playerTwoText.text = "Player 2: " + score.ToString();
    }

}