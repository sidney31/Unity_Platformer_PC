using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
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

        /*if (temp.x <= 0.3f)
        {
            temp.x = 0.3f;
        }
        if (temp.x >= 36)
        {
            temp.x = 36;
        }
        if (temp.y <= -10)
        {
            temp.y = -10;
        }
        if (temp.y >= 1.6f)
        {
            temp.y = 1.6f;
        }*/

        transform.position = temp;
    }
}
