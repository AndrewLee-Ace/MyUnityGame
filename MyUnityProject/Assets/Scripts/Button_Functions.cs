using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Button_Functions : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    // Start is called before the first frame update
    //hi
    void Start()
    {
        if(gameObject.tag == "Resume" || gameObject.tag == "Main Menu")
        {
            gameObject.SetActive(false);
        }
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void PlayGame()
    {
        string s = inputField.text;
        PersistantData.Instance.SetName(s);
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
    
    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

     public void ClearData()
    {
        PlayerPrefs.DeleteAll();
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

}
