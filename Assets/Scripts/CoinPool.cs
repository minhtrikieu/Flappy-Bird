using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    public GameObject coinPreb;

    private Vector2 coinPoisition = new Vector2(2.98f, 2.5f);
    // Start is called before the first frame update
    void Start()
    {
        createCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void createCoin()
    {
        Instantiate(coinPreb, coinPoisition, Quaternion.identity);
    }
}
