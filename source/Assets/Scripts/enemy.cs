using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float enemySpeed = 1.5f;
    private Transform player;

    SpriteRenderer sr;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        sr.flipX = player.position.x > transform.position.x ? true : false;
        transform.position += new Vector3(player.position.x > transform.position.x ? 1 : -1, 0, 0) * enemySpeed * Time.deltaTime;
    }
}
