using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BirdMove>() != null)
        {
            Debug.Log("Star Collected");
        }
    }
}
