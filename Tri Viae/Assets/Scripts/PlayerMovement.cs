using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Tilemaps;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{    
    public float moveSpeed = 6f;
    public SpriteRenderer entity;
	public Rigidbody2D rb;
	Vector2 movement;

 	// Update is called once per fram

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        if (movement.x > 0)
            {
                entity.flipX = false;  
            }
            
        if (movement.x < 0)
            {
                entity.flipX = true;
            }
        if(rb.velocity.x != 0||rb.velocity.y != 0){
            SoundHandler.SoundHandlerPlay("Walk");
        }
    }
}