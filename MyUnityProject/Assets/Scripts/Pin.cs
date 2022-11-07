using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] GameObject controller;
    [SerializeField] AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        // if (GetComponent<AudioSource>() == null)
        // {
        //     audio = GetComponent<AudioSource>();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider){
         //AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
         
     }
}
