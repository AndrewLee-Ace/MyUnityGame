using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] AudioSource pop_sound;
    [SerializeField] AudioSource deflate_sound;
    private GameObject balloon;
    private Scoring scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
       if (pop_sound == null){
        pop_sound = GetComponent<AudioSource>();
       } 

       if (deflate_sound == null){
        deflate_sound = GetComponent<AudioSource>();
       } 

       if (scoreKeeper == null){
            scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<Scoring>();
        }

       InvokeRepeating("GrowBalloon", 5.0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        // if (gameObject.transform.localScale.x  > 0.8f|| gameObject.transform.localScale.y > 0.8f){
        //     CancelInvoke("GrowBalloon");
        //     // InvokeRepeating("ShrinkBalloon", 1f, 0.3f);
        // }
    }

     private void OnTriggerEnter2D (Collider2D collision){
        if(collision.gameObject.tag == "Projectile"){
            AudioSource.PlayClipAtPoint(pop_sound.clip, transform.position);
            Destroy(gameObject);

            if (gameObject.transform.localScale.y <= 1f && gameObject.transform.localScale.y > 0.7f)
                scoreKeeper.UpdateScore(1);

            if (gameObject.transform.localScale.y <= 0.7f && gameObject.transform.localScale.y > 0.65f)
                scoreKeeper.UpdateScore(2);

            if (gameObject.transform.localScale.y <= 0.65f && gameObject.transform.localScale.y > 0.6f)
                scoreKeeper.UpdateScore(3);

            if (gameObject.transform.localScale.y <= 0.6f && gameObject.transform.localScale.y > 0.5f)
                scoreKeeper.UpdateScore(4);    

            if (gameObject.transform.localScale.y == 0.5f) 
                scoreKeeper.UpdateScore(5);   
        }

        if (gameObject.transform.localScale.y >= 1f){
            AudioSource.PlayClipAtPoint(deflate_sound.clip, transform.position);
            Destroy(gameObject);
        } 
       
    }

    private void GrowBalloon()
    {
        if(transform.localScale.x > 0f)
            gameObject.transform.localScale += new Vector3(.025f, .025f, 0f);
        else
            gameObject.transform.localScale += new Vector3(-.025f, .025f, 0f);
    }

    // private void ShrinkBalloon()
    // {
    //      if(transform.localScale.x > 0f && transform.localScale.x > 0.8f)
    //         gameObject.transform.localScale += new Vector3(-.025f, -.025f, -0f);
    //     else if (transform.localScale.x < 0f && transform.localScale.x > 0.8f)
    //         gameObject.transform.localScale += new Vector3(.025f, -.025f, -0f);
    // }

    
}
