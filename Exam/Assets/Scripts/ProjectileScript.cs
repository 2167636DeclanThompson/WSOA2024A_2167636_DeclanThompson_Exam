using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public HealthScript healthScript;    
    public Animator animator;
    public Vector2 initialVelocity;
    public Rigidbody2D rigidBody;
    public float Speed = 22;
    public bool isGrounded;
    public bool Hitting;
    public bool Flying;
    public int Damage = 1;
     

    private void Start()
    {
        StartCoroutine(Shoot());
        Flying = false;  
        Hitting = false;
        rigidBody.position = new Vector2(12.5f, -4.58f);        
        animator = GetComponent<Animator>();
        isGrounded = true;        
        rigidBody.velocity = (initialVelocity * Speed);
        
        
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        
        if (collider.gameObject.name == "Ellen")
        {
            Hitting = true;
            healthScript.HP = healthScript.HP - Damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Ellen")
        {
            Hitting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Wall")
        {
            Hitting = false;
            rigidBody.velocity = (initialVelocity * 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Wall")
        {
            Flying = false;
            Hitting = false;
            rigidBody.velocity = (initialVelocity * 0);
        }
    }

    private void Update()
    {
        if (Hitting == true)
        {
            animator.SetBool("Flying", false);
            animator.SetBool("Hit", true);            
        }

        if (Flying == true)
        {
            animator.SetBool("Flying", true);
            animator.SetBool("Hit", false);
        }
    }

    private IEnumerator Hit()
    {
        if (Hitting == false)
        {
            yield return new WaitForSeconds(0.45f);
            Start();
        }
        
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.9f);
        animator.SetBool("Flying", true);
        animator.SetBool("Hit", false);
        Flying = true;        
        Start();
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.8f);
        Flying = true;
        initialVelocity.x = 1;
    }
        
}
