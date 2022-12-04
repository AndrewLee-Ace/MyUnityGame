using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleeing : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector2 dir = player.transform.position - transform.position;

        if (distance < 10)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, -(speed * Time.deltaTime));
        }

        if (transform.position.y <= -5.5f)
        {
            //transform.position = transform.position + new Vector3(0, 5f, 0);
            transform.Translate(Vector3.up * Time.deltaTime * 5);
        }
            
    }

    

   
}
