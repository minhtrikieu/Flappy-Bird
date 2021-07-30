using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int mode = 0;
    public static int temp;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<Bullet>() != null)
        {
            //If the bird hits the trigger collider of the coin
            //tell the game control that the bird needs power
            //other.GetComponent<Bullet>().skipTheCollider();
            mode = 1;
            temp = mode;
            Destroy(gameObject);
        }
    }
    public int returnMode()
    {
        mode = temp;
        return mode;
    }
}
