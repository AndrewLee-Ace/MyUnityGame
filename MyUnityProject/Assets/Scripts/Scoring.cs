using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI sceneText;
    public int score;
    const int SCORE_TO_ADVANCE = 32;
    public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        DisplayLevel();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        DisplayScore();

        if (score >= SCORE_TO_ADVANCE)
            AdvanceLevel();
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
