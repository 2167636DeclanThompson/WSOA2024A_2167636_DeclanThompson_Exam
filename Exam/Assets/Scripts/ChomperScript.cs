using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperScript : MonoBehaviour
{
    public CharacterController2D characterController;
    public HealthScript healthScript;
    public EnemyPatrol enemyPatrol;
    public ChomperBite chomperBite;
    public Animator Ellen;
    public Rigidbody2D rigidBody;
    public float Health = 1;
    public int Damage = 1;
    public bool Attacking;
    public bool isGrounded;
    public bool isDying;

    private void Start()
    {
        isGrounded = true;
        isDying = false;
        Attacking = false;
    }
    private IEnumerator KnockBack()
    {
        yield return new WaitForSeconds(0.7f);
        characterController.KnockbackCount = characterController.KnockbackLength;
        if (characterController.transform.position.x < transform.position.x)
        {
            characterController.KnockFromRight = true;
        }
        else
        {
            characterController.KnockFromRight = false;
        }
        enemyPatrol.enabled = false;
    }
    // gamesplusjames. "Knockback & Stomping Enemies - Unity 2D Platformer Tutorial - Part 11," YouTube, March 6, 2015. [Video file] Available: https://www.youtube.com/watch?v=sdGeGQPPW7E. [Accessed: 17 June 2020]


    public void Update()
    {
        
        if (Attacking == true)
        {
            StartCoroutine(KnockBack());
            
        }
        else if (Attacking == false)
        {
            enemyPatrol.enabled = true;
        }

        if (Health == 0)
        {
            Attacking = false; 
            isDying = true;
            enemyPatrol.enabled = false;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Ellen")
        {
            
            healthScript.HP = healthScript.HP - 1;
        }
    }
    

    public void OnCollisionEnter2D(Collision2D collider)
    {
        
            if (collider.gameObject.name == "Ellen" && Attacking == false)
            {
                Health = Health - characterController.Damage;
            }
        }
    }




    

    

    



