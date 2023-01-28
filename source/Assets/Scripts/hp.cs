using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hp : MonoBehaviour
{
    public int PlayerHp = 3;
    public TextMeshProUGUI PlayerHpText;


    void Start()
    {
    }

    void Update()
    {
        PlayerHpText.text = PlayerHp.ToString() + "/3";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerHp--;
        }
    }
}
