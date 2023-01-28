using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed = 4f;
    public float jumpForce = 15f;
    public float bebebe;
    
    public bool move;

    public Animator anime;
    private Transform player;


    Rigidbody2D rb;
    SpriteRenderer sr; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        anime.SetBool("inGround", true);
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");

        anime.SetBool("stay", movement != 0 ? false : true);

        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && (Mathf.Abs(rb.velocity.y) == 0) && !(anime.GetBool("onStairs")))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anime.SetBool("inGround", false);
        }
        if (Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            anime.SetBool("inGround", true);
        }
        if (movement < 0)
        {
            sr.flipX = true;
        }
        if (movement > 0)
        {
            sr.flipX = false;
        }

        anime.SetFloat("speed", Mathf.Abs(rb.velocity.y));

        float stairsMove = Input.GetAxis("Vertical");

        anime.SetBool("climb", stairsMove != 0 ? true : false);
        
        if (anime.GetBool("onStairs")){
            transform.position += new Vector3(0, stairsMove, 0) * speed * Time.deltaTime;
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.isKinematic = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stairs" && collision.isTrigger)
        {
            anime.SetBool("onStairs", true);
            print("on stairs");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stairs" && collision.isTrigger)
        {
            anime.SetBool("onStairs", false);
        }
    }
}