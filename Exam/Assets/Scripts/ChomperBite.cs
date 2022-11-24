using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperBite : MonoBehaviour
{
    public ChomperScript chomperScript;
    public bool Attacking;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ellen")
        {
            chomperScript.Attacking = true;
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ellen")
        {
            chomperScript.Attacking = false;
            
        }
    }
}
