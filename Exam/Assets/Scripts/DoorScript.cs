using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Ellen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager.HasKey == true)
        {
            SceneManager.LoadScene(4);
        }
    }
}
