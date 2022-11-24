using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float EnemySpeed;
    public Rigidbody2D rigidBody;
    public LayerMask groundLayers;
    public Transform groundCheck;
    public bool isFacingRight = true;
    public RaycastHit2D rayCast;
    public bool Shooting;

    private void Start()
    {
        Shooting = false;
    }

    private void Update()
    {
        rayCast = Physics2D.Raycast(groundCheck.position, -transform.up, 2f, groundLayers);  
               
    }

    private void FixedUpdate()
    {
        if (rayCast.collider != false)
        {
            if (isFacingRight == true)
            {
                rigidBody.velocity = new Vector2(EnemySpeed, rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity = new Vector2(-EnemySpeed, rigidBody.velocity.y);
            }            
                       
        }
        else
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
            
        }
    }
        
}
