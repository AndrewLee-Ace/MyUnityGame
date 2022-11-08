using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Movement : MonoBehaviour
{
     private float direction = 1;
     private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(15 * direction, 0f, 0f);
        transform.position = transform.position + movement * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Barrier"){
            direction = direction * -1f;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

       
    }

}    
