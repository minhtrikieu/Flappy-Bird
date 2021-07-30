using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 100)
        {
            Die();
        }
    }
    public void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        anim.SetTrigger("Die");
        Destroy(gameObject);
    }
}
