using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnMultiplayer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BirdMove>() != null && other.GetComponent<BirdMove>().playerOrder == 1)
        {
            //If the bird hits the trigger collider in between the columns then
            //tell the game control that the bird scored.
            GameControlMultiplayer.instance.PLayerOneScored();
        }
        else if (other.GetComponent<BirdMove>() != null && other.GetComponent<BirdMove>().playerOrder == 2)
        {
            //If the bird hits the trigger collider in between the columns then
            //tell the game control that the bird scored.
            GameControlMultiplayer.instance.PLayerTwoScored();
        }
    }
}
