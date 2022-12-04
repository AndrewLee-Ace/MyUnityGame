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
    //public TextMeshProUGUI healthText;
    public Button gameOverButton;
    public Button pauseButton;
    public int score;
    const int SCORE_TO_ADVANCE = 32;
    public int currentLevel;
    public float timeLeft;
    public bool timerOn = false;
    public string playerName;
    public int playerScore;
    // public int playerHealth;
    // public int health;

    
    // Start is called before the first frame update
    void Awake()
    {
        pauseButton = GetComponent<Button>();
    }
    void Start()
    {
        //playerHealth = PersistantData.Instance.GetHealth();
        playerScore = PersistantData.Instance.GetScore();
        playerName = PersistantData.Instance.GetName();
        gameOverText.gameObject.SetActive(false);
        gameOverButton.gameObject.SetActive(false);
        pauseButton = GameObject.Find("Pause").GetComponent<Button>();
        timerOn = true;
        score = 0;
        //health = 3;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        DisplayLevel();
        DisplayScore();
        //DisplayHealth();
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
                pauseButton.gameObject.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        playerScore += scoreToAdd;
        PersistantData.Instance.SetScore(playerScore);
        DisplayScore();

        if (score >= SCORE_TO_ADVANCE)
            AdvanceLevel();
    }

    // public void UpdateHealth(int healthToPut)
    // {
    //     health += healthToPut;;
    //     playerHealth += healthToPut;
    //     PersistantData.Instance.SetHealth(playerHealth);
    //     DisplayHealth();
    // }

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

    // public void DisplayHealth()
    // {
    //     healthText.text = "Health: " + health;
    // }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(currentLevel + 1);
    }

    
}
