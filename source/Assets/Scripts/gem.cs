using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gem : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;


    void Start()
    {
        score = 0;
    }

    void Update()
    {
         scoreText.text = score.ToString()+"/3";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger && collision.gameObject.tag == "gem")
        {
            Destroy(collision.gameObject);
            score++;
            if (score == 3)
            {
                Time.timeScale = 0;
            }
        }
    }
}
