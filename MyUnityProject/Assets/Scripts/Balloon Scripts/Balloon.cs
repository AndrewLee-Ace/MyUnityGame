using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] AudioSource source;
    private GameObject balloon;
    private Scoring scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
       if (source == null){
        source = GetComponent<AudioSource>();
       } 

       if (scoreKeeper == null){
            scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<Scoring>();
        }

       InvokeRepeating("GrowBalloon", 5.0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x  > 0.8f|| gameObject.transform.localScale.y > 0.8f){
            CancelInvoke("GrowBalloon");
            // InvokeRepeating("ShrinkBalloon", 1f, 0.3f);
        }
    }

     private void OnTriggerEnter2D (Collider2D collision){
        if(collision.gameObject.tag == "Projectile"){
            AudioSource.PlayClipAtPoint(source.clip, transform.position);
            Destroy(gameObject);
            scoreKeeper.UpdateScore(5);
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
