using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private Rigidbody2D body;
    private bool grounded;
    [SerializeField] private GameObject pins;
    // public ProjectileBehaviour pins;
    public Transform launchOffest;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flip player left/right
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector2(0.5f, 0.5f);
        else if (horizontalInput < -0.1f)
            transform.localScale = new Vector2(-0.5f, 0.5f);    

        //Jump
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //Shoot
        if (Input.GetButtonDown("Fire1")){
            Instantiate(pins, launchOffest.position, Quaternion.identity);
        }
    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

}
