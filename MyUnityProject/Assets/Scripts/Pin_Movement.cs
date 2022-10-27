using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin_Movement : MonoBehaviour
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

     private void OnCollisionEnter2D(Collision2D collision){
         Destroy(gameObject);
     }
}
