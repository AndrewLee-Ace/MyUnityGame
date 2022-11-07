using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin_Movement : MonoBehaviour
{
    // private float direction = 1;
    private Vector3 movement;
    private float direction = 2.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(0f, 15 * direction, 0f);
        // transform.position = transform.position + movement * Time.deltaTime;

        transform.position = transform.position + movement * Time.deltaTime;
    }

     private void OnTriggerEnter2D(Collider2D collision){
         if (collision.gameObject.tag == "Roof"){
            Destroy(gameObject);
         }  
     }

    
}
