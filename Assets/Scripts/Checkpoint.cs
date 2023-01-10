using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    AudioManager audioManager;
    bool triggered;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Awake()
    {
        triggered = false;
    }

    // called whenever another collider enters our zone (if layers match)
    void OnTriggerEnter2D(Collider2D collider)
    {
        // check we haven't been triggered yet!
        if (!triggered)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                if (LevelManager.instance.currentLevel == 1 && ScoreManager.GetInstance().getScore() >= 10)
                {
                    Trigger();
                }
                else if (LevelManager.instance.currentLevel == 2 && ScoreManager.GetInstance().getScore() >= 30)
                {
                    Trigger();
                }
                else if (LevelManager.instance.currentLevel == 3 && ScoreManager.GetInstance().getScore() >= 50)
                {
                    Trigger();
                }
                else if (LevelManager.instance.currentLevel == 4 && ScoreManager.GetInstance().getScore() >= 60)
                {
                    Trigger();
                }
            }
        }
    }

    void Trigger()
    {
        triggered = true;
        audioManager.playMySound("LevelComplete");
        LevelManager.instance.displayLevelComplete();
    }
}
