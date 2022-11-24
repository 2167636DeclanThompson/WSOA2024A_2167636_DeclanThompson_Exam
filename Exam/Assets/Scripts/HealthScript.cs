using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public Animator heart1, heart2, heart3;
    public CharacterController2D characterController;
    public int HP = 3;
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    public bool Dying;

    private void Start()
    {
         
        
    }
    public void Update()
    {
        if (HP == 2)
        {
            heart3.SetBool("Broken", true);      
        }
        else if (HP == 1)
        {
            heart2.SetBool("Broken", true);
        }
        else if (HP == 0)
        {
            StartCoroutine(Disable());
            heart1.SetBool("Broken", true);
            Dying = true;
        }
        
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }


}
