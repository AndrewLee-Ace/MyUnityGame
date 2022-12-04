using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public int currentLevel;
    private Scoring scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (scoreKeeper == null){
            scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<Scoring>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            AdvanceLevel();
            scoreKeeper.UpdateScore(10);
        }
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(currentLevel + 1);
    }
}
