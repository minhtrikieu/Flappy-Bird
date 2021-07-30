using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }
}
