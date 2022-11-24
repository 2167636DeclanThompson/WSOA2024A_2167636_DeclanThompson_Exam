using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperAnimator : MonoBehaviour
{
    public ChomperScript chomperScript;
    public EnemyPatrol enemyScript;
    private Animator animator;
    public ChomperBite chomperBite;

    public void Start()
    {

        chomperScript = GetComponentInParent<ChomperScript>();
        enemyScript = GetComponentInParent<EnemyPatrol>();
        animator = GetComponent<Animator>();        
    }

    public void Update()
    {
        ChomperAnimation();
    }

    public void ChomperAnimation()
    {
        if (chomperScript.isGrounded == true)
        {
            animator.SetBool("Grounded", true);
        }

        if(chomperScript.Attacking == true)
        {
            animator.SetBool("Attack", true);
        }
        else if (chomperScript.Attacking == false)
        {
            animator.SetBool("Attack", false);
        }

        if (chomperScript.isDying == true)
        {
            animator.SetBool("Dying", true);
            enemyScript.enabled = false;
            StartCoroutine(ChomperDeath());
                       
        }
    }

    private IEnumerator ChomperDeath()
    {        
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
    
}
