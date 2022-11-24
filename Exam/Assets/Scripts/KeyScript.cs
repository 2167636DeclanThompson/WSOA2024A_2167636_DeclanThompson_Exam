using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    public GameManager gameManager;
    public Image Key;
    public bool KeyText;
    

    private void Start()
    {
        KeyText = false;        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Ellen")
        {
                   
            gameManager.HasKey = true;
            KeyText = true;            
            Destroy(gameObject);
            
            
        }

    }

    
}
