using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        temp.y = player.position.y;

        if (temp.x <= -2.5f)
        {
            temp.x = -2.5f;
        }
        if (temp.x >= 34)
        {
            temp.x = 34;
        }
        if (temp.y <= -3.7f)
        {
            temp.y = -3.7f;
        }
        if (temp.y >= 0)
        {
            temp.y = 0;
        }

        transform.position = temp;
    }
}
