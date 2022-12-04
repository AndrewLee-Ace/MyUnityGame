using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] int playerHealth;

    public static PersistantData Instance;

    public void Awake()
    {
         if (Instance == null)
         {
            Instance = this;

            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
       playerName = "";
       playerScore = 0;
    }

    public void SetName(string name){
        playerName = name;
    }

    public void SetScore(int score){
        playerScore = score;
    }

    public string GetName(){
        return playerName;
    } 

    public int GetScore(){
        return playerScore;
    }
}
