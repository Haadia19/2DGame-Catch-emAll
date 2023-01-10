using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject[] menus;

    public int currentLevel = 0;
    JellyCreateScript jellyCreate;
    AudioManager audioManager;

    public static LevelManager instance;
    public bool reload = false;
    // Start is called before the first frame update
    private void Start()
    {
        jellyCreate = FindObjectOfType<JellyCreateScript>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else //error handling
        {
            Destroy(gameObject);
        }
        hideAllLevels();
        hideRulesMenu();
    }
    public void hideAllLevels()
    {
        foreach (var level in levels)
        {
            level.SetActive(false);
        }
    }
    public void hideFirstMenu()
    {
        menus[0].SetActive(false);
    }
    public void DisplayFirstMenu()
    {
        this.currentLevel = 0;
        menus[0].SetActive(true);
        reload = true;
    }
    public void displayRulesMenu()
    {
        menus[1].SetActive(true);
    }
    public void hideRulesMenu()
    {
        menus[1].SetActive(false);
    }
    public void displayGameOverMenu()
    {
        menus[2].SetActive(true);
    }
    public void hideGameOverMenu()
    {
        menus[2].SetActive(false);
    }
    public void displayLevelComplete()
    {
        Time.timeScale = 0;
        menus[3].SetActive(true);
    }
    public void HideLevelComplete()
    {
        Time.timeScale = 1;
        menus[3].SetActive(false);
    }
    public void HideGameComplete()
    {
        menus[4].SetActive(false);
    }

    public void loadNextLevel()
    {
        if (currentLevel < levels.Length)
        {
            hideAllLevels();    
            ScoreManager.GetInstance().resestScore();
            levels[currentLevel].SetActive(true);
            currentLevel++;
        }
        else if(currentLevel == 4)
        {
            hideAllLevels();
            menus[4].SetActive(true);
            audioManager.playMySound("Won");
            if (ScoreManager.GetInstance().getScore() > DatabaseManager.GetInstance().getScore())
            {
                DatabaseManager.GetInstance().updateScore(ScoreManager.GetInstance().getScore());
            }
        }
        else
        {
            hideAllLevels();
            levels[currentLevel].SetActive(true);
        }
    }
}
