using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager
{
    private int score = 0;
    private int lifelines = 3;
    private int Health = 100;

    private Text scoreText;
    private Text lifeText;
    private Text healthText;
    private Text catchText;
    private Text highScoreText;


    private static ScoreManager instance;
    // Start is called before the first frame update
    private ScoreManager()
    {
        scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
        lifeText = GameObject.FindWithTag("Life").GetComponent<Text>();
        healthText = GameObject.FindWithTag("Health").GetComponent<Text>();
        catchText = GameObject.FindWithTag("Catch").GetComponent<Text>();
        highScoreText = GameObject.FindWithTag("highscore").GetComponent<Text>();
    }
    public static ScoreManager GetInstance()
    {
        if (instance == null)
        {
            instance = new ScoreManager();
        }
        return instance;
    }
    public void addScore()
    {
        this.score += 10;
        scoreText.text = "Score: " + this.score;
    }
    public void getColor(string color)
    {
        //catchText.text = "Catch " + color + " jellies";
    }
    public void minusScore()
    {
        this.score -= 10;
        scoreText.text = "Score: " + this.score;
    }
    public void resestScore()
    {
        if(LevelManager.instance.reload)
        {
            this.lifelines = 3;
            //this.Health = 100;
        }
        scoreText.text = "Score: " + this.score;
        //lifeText.text = "Life(s): " + this.lifelines;
        //healthText.text = "Health: " + this.Health;
    }
    public int getScore()
    {
        return this.score;
    }
    public void reduceLifeline()
    {
        this.lifelines -= 1;
        //lifeText.text = "Life(s): " + this.lifelines;
    }
    public void setLifeline()
    {
        this.lifelines = 0;
        //lifeText.text = "Life(s): " + this.lifelines;
    }
    public int getLifeline()
    {
        return this.lifelines;
    }
    public void reduceHealth()
    {
        this.Health -= 20;
        //healthText.text = "Health: " + this.Health;
    }
    public int getHealth()
    {
        return this.Health;
    }
    public void displayHighScore()
    {
        highScoreText.text = "HighScore: " + DatabaseManager.GetInstance().getScore();
    }
}
