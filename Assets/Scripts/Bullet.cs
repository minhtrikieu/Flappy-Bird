using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    //public GameObject impactEffect;
    private Animator anim;
    public GameObject columnPreFab;

    public GameObject columnOne;
    public GameObject columnTwo;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        anim = GetComponent<Animator>();

        //Transform column = Instantiate(columnPreFab) as Transform;
        //var column = Instantiate(columnPreFab) as Transform;

        Physics2D.IgnoreCollision(columnPreFab.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        /*
        Physics2D.IgnoreCollision(columnPreFab.GetChild(0).GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(columnPreFab.GetChild(2).GetComponent<Collider2D>(), GetComponent<Collider2D>());*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemyTemp = collision.GetComponent<Enemy>();
        if(enemyTemp != null)
        {
            enemyTemp.takeDamage(damage);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);
        anim.SetTrigger("Impact");
        //anim.SetTrigger("Flap");
        Destroy(gameObject);
    }
    public void skipTheCollider()
    {
        Debug.Log("The coin is collected!");
        /*
        Debug.Log(columnPreFab.GetChild(0).name);
        Physics2D.IgnoreCollision(columnPreFab.GetChild(0).GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(columnPreFab.GetChild(2).GetComponent<Collider2D>(), GetComponent<Collider2D>());*/
    }

}
