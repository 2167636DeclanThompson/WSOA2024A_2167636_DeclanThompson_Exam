using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterScript : MonoBehaviour
{
    public CharacterController2D characterController;
    public HealthScript healthScript;
    public bool isGrounded;
    public bool Dying;
    public float Health = 1;
    public int Damage = 1;
    public bool Shooting;

    public void Start()
    {
        isGrounded = true;
        Dying = false;
        Shooting = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Ellen")
        {
            Health = Health - characterController.Damage;
        }

    }
          

    private void Update()
    {
        if (Health == 0)
        {
            Dying = true;
        }
    }
}


