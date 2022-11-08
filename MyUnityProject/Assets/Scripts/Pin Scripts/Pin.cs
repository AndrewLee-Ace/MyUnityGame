using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
  
    [SerializeField] AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
        // if (GetComponent<AudioSource>() == null)
        // {
        //     audio = GetComponent<AudioSource>();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Roof"){
            Destroy(gameObject);
        }  

        if (collision.gameObject.tag == "Obstacle"){
            Destroy(gameObject);
        }  

    }
}
