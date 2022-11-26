using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private GameObject pins;
    [SerializeField] public Animator animator;
    private Rigidbody2D body;
    private bool grounded;
    private bool isShooting = false;

    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;
    const int FIRE = 3;
    
    
    public Transform launchOffest;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        animator.SetInteger("Motion", IDLE);
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flip player left/right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector2(9f, 9f);
            isShooting = false;
            if (grounded && !isShooting)
            {
                 animator.SetInteger("Motion", RUN);
            }
        }
            
        else if (horizontalInput < -0.1f)
        {
            transform.localScale = new Vector2(-9f, 9f);
            isShooting = false;
            if (grounded && !isShooting)
            {
                animator.SetInteger("Motion", RUN);
            }
            
        }
        else if (horizontalInput == 0 && grounded && !isShooting)
        {
            isShooting = false;
            animator.SetInteger("Motion", IDLE);
        }        

        //Jump
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            isShooting = false;
            Jump();
            animator.SetInteger("Motion", JUMP);
        }
            

        //Shoot
        if (Input.GetButtonDown("Fire2") && horizontalInput == 0){
            Shoot();
            isShooting = true;
            animator.SetInteger("Motion", FIRE);
        }
    }

    private void Shoot()
    {
        Instantiate(pins, launchOffest.position, Quaternion.identity);
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
