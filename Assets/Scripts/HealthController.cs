using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Image requiredJelly;
    public Sprite[] jellies;
    void Update()
    {
        if (LevelManager.instance.currentLevel == 1)
        {
            offset.x = player1.transform.position.x;
        }
        else if (LevelManager.instance.currentLevel == 2)
        {
            offset.x = player2.transform.position.x;
        }
        else if (LevelManager.instance.currentLevel == 3)
        {
            offset.x = player3.transform.position.x;
        }
        else if (LevelManager.instance.currentLevel == 4)
        {
            offset.x = player4.transform.position.x;
        }
        offset.y = 0;
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);

        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < ScoreManager.GetInstance().getLifeline() ; i++)
        {
            hearts[i].sprite = fullHeart;
        }
        requiredJelly.sprite = jellies[JellyCreateScript.instance.jelly];
    }
    public void setHealth(float value)
    {
        slider.maxValue = 100f;
        slider.value = value;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);

    }
}
