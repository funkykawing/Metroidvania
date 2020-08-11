﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    //necessary for animations and physics
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    //for the face direction of the character
    private bool facingRight = true;

    //variables to play with
    public float speed = 2.0f;
    public float horizMovement; //-1[OR]1[OR]0 if using GetAxis but GetAxisRaw below

    private void Start()
    {
        //define the gameobjects found on the player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    //handles the input for physics
    private void Update()
    {
        //check direction given by player
        horizMovement = Input.GetAxis("Horizontal");
    }

    //handles running the physics
    private void FixedUpdate()
    {
        //move the character left and right
        rb2D.velocity = new Vector2(horizMovement * speed, rb2D.velocity.y);
        Flip(horizMovement);
        myAnimator.SetFloat("runSpeed", Mathf.Abs(horizMovement));
    }

    //flipping function
    private void Flip(float horizontal) 
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {

            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }   
    }
}