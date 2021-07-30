using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumPool : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject columnPrefab;
   
    public int columnPoolSize = 5;                                    //How many columns to keep on standby.
    public float spawnRate = 3f;                                    //How quickly columns spawn.
    public float columnMin = -3f;                                    //Minimum y value of the column position.
    public float columnMax = 5f;                                    //Maximum y value of the column position.

    private GameObject[] columns;                                    //Collection of pooled columns.
    private int currentColumn = 0;                                    //Index of the current column in the collection.
   
    private Vector2 objectPoolPosition = new Vector2(-15, -25);        //A holding position for ouunused columns offscreen.
    
    private float spawnXPosition = 10f;
    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;
        
        //Initialize the columns collection.
        columns = new GameObject[columnPoolSize];
        //Loop through the collection... 
        createColumn();
    }


    //This spawns columns as long as the game is not over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            //Set a random y position for the column
            float spawnYPosition = Random.Range(columnMin, columnMax);

            //...then set the current column to that position.
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            //Increase the value of currentColumn. If the new size is too big, set it back to zero
            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
                columns = new GameObject[columnPoolSize];
                createColumn();
            }
        }
    }
    private void createColumn()
    {
        for (int i = 0; i < columnPoolSize; i++)
        {
            //...and create the individual columns.
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
            
        }
    }
}
