using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterAnimator : MonoBehaviour
{
    public SpitterScript spitterScript;    
    private Animator animator;

    public void Start()
    {
        spitterScript = GetComponentInParent<SpitterScript>();        
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        SpitterAnimation();
    }

    public void SpitterAnimation()
    {
        if (spitterScript.isGrounded == true )
        {
            animator.SetBool("Grounded", true);
        }

        if (spitterScript.Shooting == true)
        {
            animator.SetBool("Shooting", true);            
        }

        if (spitterScript.Dying == true)
        {
            animator.SetBool("Death", true);            
            StartCoroutine(SpitterDeath());
        }
        
    }

    private IEnumerator SpitterDeath()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
