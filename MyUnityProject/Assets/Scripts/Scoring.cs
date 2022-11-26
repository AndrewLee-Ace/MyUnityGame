using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI sceneText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public Button gameOverButton;
    public int score;
    const int SCORE_TO_ADVANCE = 32;
    public int currentLevel;
    public float timeLeft;
    public bool timerOn = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
        gameOverText.gameObject.SetActive(false);
        gameOverButton.gameObject.SetActive(false);
        timerOn = true;
        score = 0;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        DisplayLevel();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else 
            {
                timeLeft = 0;
                timerOn = false;
                gameOverText.gameObject.SetActive(true);
                gameOverButton.gameObject.SetActive(true);
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        DisplayScore();

        if (score >= SCORE_TO_ADVANCE)
            AdvanceLevel();
    }

    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text= string.Format("Time Remaining: {1:00}", minutes, seconds);
    }
    
    public void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        sceneText.text = "Level: " + (currentLevel + 1);
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(currentLevel + 1);
    }

    
}
