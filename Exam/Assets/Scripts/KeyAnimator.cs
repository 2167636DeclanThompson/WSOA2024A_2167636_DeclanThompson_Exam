using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimator : MonoBehaviour
{
    public Animator Key;
    public KeyScript keyScript;
    public GameManager gameManager;

    public void Update()
    {
        if (gameManager.HasKey == true)
        {
            Key.SetBool("Key", true);
        }
    }

}
