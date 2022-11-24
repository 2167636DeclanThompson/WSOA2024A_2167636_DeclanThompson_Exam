using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    public CharacterController2D characterController;
    public ChomperScript chomperScript;
    public HealthScript healthScript;
    public ProjectileScript projectileScript;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("HorizontalSpeed", 0);
    }

    void Update()
    {
        AnimationController();
    }

    public void AnimationController()
    {
        if (characterController.rigidBody.velocity.x < 0 && characterController.Speed >= 5)
        {
            animator.SetFloat("HorizontalSpeed", 1);
        }
        else if (characterController.rigidBody.velocity.x > 0 && characterController.Speed >= 5)
        {
            animator.SetFloat("HorizontalSpeed", 1);
        }
        else if (characterController.Speed == 0)
        {
            animator.SetFloat("HorizontalSpeed", 0);
        }

        if (characterController.rigidBody.velocity.x < 0 && characterController.Speed > 8)
        {
            animator.SetFloat("HorizontalSpeed", 2);
        }
        else if (characterController.rigidBody.velocity.x > 0 && characterController.Speed > 8)
        {
            animator.SetFloat("HorizontalSpeed", 2);
        }
        else if (characterController.rigidBody.velocity.x == 0 && characterController.Speed >= 5 )
        {
            animator.SetFloat("HorizontalSpeed", 0);
        }

        if (characterController.Pushing == true && characterController.rigidBody.velocity.x > 0)
        {
            animator.SetBool("Pushing", true);
        }
        else if (characterController.Pushing == true && characterController.rigidBody.velocity.x < 0)
        {
            animator.SetBool("Pushing", true);
        }
        else
        {
            animator.SetBool("Pushing", false);
        }


        if (characterController.isGrounded() == false)
        {
            animator.SetBool("Grounded", false);
            animator.SetFloat("VerticalSpeed", 1);            
        }
        else if (characterController.isGrounded() == true)
        {
            animator.SetBool("Grounded", true);
            animator.SetFloat("VerticalSpeed", 0);
        }
        
        if (chomperScript.Attacking == true)
        {
            StartCoroutine(Attack());
        }

        if (projectileScript.Hitting == true)
        {
            animator.SetBool("Hurt", true);
            StartCoroutine(Wait());
        }

        

        if (healthScript.Dying == true)
        {
            animator.SetBool("Dying", true);
            animator.SetFloat("TimeOut", 1);
            characterController.enabled = false;
            characterController.rigidBody.velocity = new Vector2(0,0);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("Hurt", false);
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.7f);
        animator.SetBool("Hurt", true);
        StartCoroutine(Wait());
    }
}
