using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    
    private void Start()
    {
        //GameObject bullet = GameObject.FindGameObjectWithTag("Bullet");
        //Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
   
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BirdMove>() != null)
        {
            //If the bird hits the trigger collider in between the columns then
            //tell the game control that the bird scored.
            GameControl.instance.BirdScored();
        }
    }
}
