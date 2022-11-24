using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float horizontalMovement = 0;
    public float jumpSpeed = 200;
    public Rigidbody2D rigidBody;
    public float Speed = 0;
    public Transform Feet;
    public LayerMask GroundLayers;
    public KeyCode Sprint;        
    public float Damage = 1;    
    public bool isDying;
    public bool Pushing;
    public HealthScript healthScript;
    public Animator animator;
    public float Knockback;
    public float KnockbackCount;
    public float KnockbackLength;
    public bool KnockFromRight;
   
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();        
        isDying = false;
        Pushing = false;
        Speed = 0;
    }

    private void Update()
    {
        if (KnockbackCount <= 0)
        {
            
            horizontalMovement = Input.GetAxis("Horizontal");
            

            if (horizontalMovement < 0)
            {
                if (Input.GetKey(Sprint))
                {
                    Speed = 10;
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    Speed = 5;
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                
            }
            else if (horizontalMovement > 0)
            {
                if (Input.GetKey(Sprint))
                {
                    Speed = 10;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    Speed = 5;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                                          
                
                
            }  
            else if (horizontalMovement == 0)
            {
                Speed = 0;
            }

            



            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rigidBody.AddForce(new Vector2(0, jumpSpeed));
            }

            rigidBody.velocity = new Vector2(horizontalMovement * Speed, rigidBody.velocity.y);


            

            
        }
        else
        {
            if (KnockFromRight == true)
            {
                rigidBody.velocity = new Vector2(-Knockback, Knockback);
            }
            else if (KnockFromRight == false)
            {
                rigidBody.velocity = new Vector2(Knockback, Knockback);
            }
            KnockbackCount -= Time.deltaTime;
        }

        // gamesplusjames. "Knockback & Stomping Enemies - Unity 2D Platformer Tutorial - Part 11," YouTube, March 6, 2015. [Video file] Available: https://www.youtube.com/watch?v=sdGeGQPPW7E. [Accessed: 17 June 2020] 

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Block")
        {
            Pushing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Block")
        {
            Pushing = false;
        }
    }

    public bool isGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(Feet.position, 0.5f, GroundLayers);

        if (groundCheck != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
