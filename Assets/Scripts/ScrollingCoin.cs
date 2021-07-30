using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCoin : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Start the object moving.
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }
        
    }
}
