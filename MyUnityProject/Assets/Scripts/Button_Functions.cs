using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Functions : MonoBehaviour
{
    // Start is called before the first frame update
    //hi
    void Start()
    {
        if(gameObject.tag == "Resume" || gameObject.tag == "Main Menu")
            gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Lvl 1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        if (Time.timeScale != 1f){
            Time.timeScale = 1f;
        }
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
    
    public void ToggleButton()
    {
        if (gameObject.activeSelf == true){
            gameObject.SetActive(false);
        }
        else{
            gameObject.SetActive(true);
        }
    }

    public void MoveSlider()
    {

    }
}
