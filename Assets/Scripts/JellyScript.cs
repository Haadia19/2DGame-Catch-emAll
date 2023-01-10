using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class JellyScript : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    AudioManager audioManager;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
        Rigidbody2D.drag = JellyCreateScript.instance.getGravity();
        ScoreManager.GetInstance().getColor(JellyCreateScript.instance.getJelly().tag);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Crate"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Cactus") || collision.gameObject.CompareTag("Box"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Basket"))
        {
            if (JellyCreateScript.instance.getJelly().tag == gameObject.tag)
            {
                ScoreManager.GetInstance().addScore();
                audioManager.playMySound("Add");
            }
            else if (gameObject.tag == "Black")
            {
                ScoreManager.GetInstance().minusScore();
                ScoreManager.GetInstance().reduceLifeline();
                audioManager.playMySound("LifeLost");
            }
            else
            {
                ScoreManager.GetInstance().reduceLifeline();
                audioManager.playMySound("LifeLost");
            }
            Destroy(gameObject);
        }
    }
}
