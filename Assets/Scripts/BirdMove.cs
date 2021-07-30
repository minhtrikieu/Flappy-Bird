using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    public float upForce = 150f;                    //Upward force of the "flap".
    private bool isDead = false;            //Has the player collided with a wall?

    public int playerOrder;
    private Animator anim;                    //Reference to the Animator component.
    private Rigidbody2D rb2d;                //Holds a reference to the Rigidbody2D component of the bird.

    public int gameMode;                    // Clarify the mode of game (single, multiplayer)
    

    public static GameControl instance;
    public AudioSource audioFlap;

    public RuntimeAnimatorController player2Animator;

    public GameObject text;
    public Sprite playerOneSprite;
    public Sprite playerTwoSprite;
    public int characterOrder;

    private bool checkChangeSpeed = false;

    void Start()
    {
        if (gameMode == 1)
        {
            characterOrder = this.gameObject.GetComponent<CharacterSelction>().returnValue();
            chooseCharacter(characterOrder);

        }

        //Get reference to the Animator component attached to this GameObject.
        anim = gameObject.GetComponent<Animator>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        /*if (playerOrder == 1 && gameMode == 1)
        {
            anim.runtimeAnimatorController = //Resources.Load<RuntimeAnimatorController>("Flappy Bird/Assets/Animation/Player 1");
            (RuntimeAnimatorController)Resources.Load("Animation/Player 1.controller", typeof(RuntimeAnimatorController));
            Debug.Log(anim);
        }*/
        
    }

    void Update()
    {
        if (characterOrder == 2 && gameMode == 1)
        {
            anim.runtimeAnimatorController = player2Animator as RuntimeAnimatorController;
            Debug.Log(anim);
        }

        if (gameMode == 1 && checkChangeSpeed != true)
        {
            changeSpeed();
            
        }
        
        //Don't allow control if the bird has died.
        if (isDead == false)
        {
            
            if (playerOrder == 1)
            {
                //Look for input to trigger a "flap".
                if (Input.GetKeyDown(KeyCode.W))
                {
                    audioFlap = GetComponent<AudioSource>();
                    audioFlap.Play(0);

                    //...zero out the birds current y velocity before...
                    rb2d.velocity = Vector2.zero;

                    //..giving the bird some upward force.
                    rb2d.AddForce(new Vector2(0, upForce));
                }
            }
            else if (playerOrder == 2)

            {
                //Look for input to trigger a "flap".
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    audioFlap = GetComponent<AudioSource>();
                    audioFlap.Play(0);
                  
                    //...zero out the birds current y velocity before...
                    rb2d.velocity = Vector2.zero;

                    //..giving the bird some upward force.
                    rb2d.AddForce(new Vector2(0, upForce));
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameMode == 1 && characterOrder ==1 )
        {
            // Zero out the bird's velocity
            rb2d.velocity = Vector2.zero;
            // If the bird collides with something set it to dead...
            isDead = true;
            //...tell the Animator about it...
            
            anim.SetBool("Player1Die", true);
            //...and tell the game control about it.
            GameControl.instance.BirdDied();
        }
        else if(gameMode == 1 && characterOrder == 2)
        {
            // Zero out the bird's velocity
            rb2d.velocity = Vector2.zero;
            // If the bird collides with something set it to dead...
            isDead = true;
            //...tell the Animator about it...
            
            anim.SetBool("Player2Die", true);
            //...and tell the game control about it.
            GameControl.instance.BirdDied();
        }
        else if (gameMode == 2 && playerOrder == 1)
        {
            // Zero out the bird's velocity
            // rb2d.velocity = Vector2.zero;
            // If the bird collides with something set it to dead...
            if (isDead == false)
            {
                isDead = true;
                //...tell the Animator about it...
                anim.SetBool("Player1Die", true);
                
                //...and tell the game control about it.
                GameControlMultiplayer.instance.BirdDiedMulti();
            }
        }
        else if(gameMode == 2 && playerOrder ==2)
        {
            // Zero out the bird's velocity
            // rb2d.velocity = Vector2.zero;
            // If the bird collides with something set it to dead...
            if (isDead == false)
            {
                isDead = true;
                //...tell the Animator about it...
                anim.SetBool("Player2Die", true);
                
                //...and tell the game control about it.
                GameControlMultiplayer.instance.BirdDiedMulti();
            }
        }

    }
    void chooseCharacter(int order)
    {
        if (order == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerOneSprite;
            this.gameObject.GetComponent<Transform>().localScale = new Vector3(-0.08f, 0.08f, 0);
            this.gameObject.AddComponent<PolygonCollider2D>();
        }
        else if (order == 2)
        {

            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerTwoSprite;
            this.gameObject.GetComponent<Transform>().localScale = new Vector3(-0.08f, 0.08f, 0);
            this.gameObject.AddComponent<PolygonCollider2D>();
        }
    }
    public void changeSpeed()
    {
        if(gameMode == 1)
        {
            if (this.gameObject.GetComponent<Coin>().returnMode() == 1)
            {
               
                text.SetActive(true);
                StartCoroutine(ExampleCoroutine());

                upForce = 250f;
                
                if (characterOrder == 1)
                {
                   
                    this.gameObject.GetComponent<Transform>().localScale = new Vector3(-0.05f, 0.05f, 0);
                }
                else
                {
                    this.gameObject.GetComponent<Transform>().localScale = new Vector3(-0.05f, 0.05f, 0);
                }
                checkChangeSpeed = true; // check if the power is added or not.
            }
        }
        
    }
    public bool checknSkillAcquired()
    {
        if (this.gameObject.GetComponent<Coin>().returnMode() == 1)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    IEnumerator ExampleCoroutine()
    {
        
        yield return new WaitForSeconds(5);

        Destroy(text);
        
    }

}
