﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    public int jumpForce;

    public Transform groundPoint;

    public LayerMask groundLayer;

    bool grounded;

    public GameObject deathEffect;

    public Transform effectPosition;

    public GameObject shield;

    public bool shieldOn = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        shield.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapPoint(groundPoint.position,groundLayer);
    }
    // Update is called once per frame
    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce);
        }

        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.S))
        {
            shield.gameObject.SetActive(true);
            shieldOn = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            shield.gameObject.SetActive(false);
            shieldOn = false;
        }
    }
    public void GameOver()
    {
        //Now just stop the camera controller and kill the player
        GameManager.instance.cam.followPlayer = false;
        Instantiate(deathEffect, effectPosition.position, Quaternion.identity);
        GameManager.instance.gameOver.SetActive(true);
        Destroy(gameObject);
    }
}
