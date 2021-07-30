using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using System.Linq;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;            //A reference to our game control script so we can access it statically.
    public Text scoreText;                        //A reference to the UI text component that displays the player's score.
    public GameObject gameOvertext;                //A reference to the object that displays the text which appears when the player dies.\
    public GameObject controller;
    public Text lastGametext;

    private int count = 0;
    private int score = 0;                        //The player's score.
    private int lastScore = 0;
    private int finalScore = 0;
    public bool gameOver = false;                //Is the game over?
    public float scrollSpeed = -1.5f;
    public AudioSource audioGameOver;

    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
        {
            //...set this one to be it...
            instance = this;
            ReadString();
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

    public void BirdDied()
    {
        //Activate the game over text.
        gameOvertext.SetActive(true);
        controller.SetActive(true);
        //Set the game to be over.
        gameOver = true;
        finalScore = score;
        audioGameOver = GetComponent<AudioSource>();
        audioGameOver.Play(0);
        WriteString();
    }
    public void BirdDiedMulti()
    {
        
        count++;
        Debug.Log("Collision " + count + " is recorded.");
        if (count == 2)
        {
            gameOvertext.SetActive(true);
            //Set the game to be over.
            gameOver = true;
            finalScore = score;
            audioGameOver = GetComponent<AudioSource>();
            audioGameOver.Play(0);
            count = 0;
            WriteString();
        }

    }
    public void BirdScored()
    {
        //Debug.Log("123");
        //The bird can't score if the game is over.
        if (gameOver)
            return;
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        scoreText.text = "Score: " + score.ToString();
    }

    public void WriteString()
    {
        string path = "Assets/Database/BestScoreDB.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path);
        writer.Write(finalScore.ToString()+"\n");
        writer.Close();

    }


    public void ReadString()
    {
        string path = "Assets/Database/BestScoreDB.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string lineTemp = File.ReadLines(path).Last();
        lastScore = int.Parse(lineTemp);

        lastGametext.text = "Last Scored:" + lineTemp;
        reader.Close();
    }
}
