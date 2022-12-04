using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class New_Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    //private float recoil = 3;
    [SerializeField] private GameObject pins;
    [SerializeField] public Animator animator;
    private Rigidbody2D body;
    private bool grounded;
    private bool isShooting = false;
    public int hitCount;
    public TextMeshProUGUI gameOverText;
    public Button gameOverButton;
    public Button pauseButton;
    public TextMeshProUGUI youDied;

    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;
    const int FIRE = 3;
    
    
    public Transform launchOffest;

    // Start is called before the first frame update
    void Awake()
    {
        pauseButton = GetComponent<Button>();
    }
    void Start()
    {
        youDied.gameObject.SetActive(false);
        hitCount = 3;
        pauseButton = GameObject.Find("Pause").GetComponent<Button>();
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

        if (hitCount <= 0)
        {
            Time.timeScale = 0f;
            gameOverText.gameObject.SetActive(true);
            gameOverButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            youDied.gameObject.SetActive(true);

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
        {
            grounded = true;
        }    

        if (collision.gameObject.tag == "Bleep")
        {
            Debug.Log("I'M HIT!");
            hitCount -=1;
            transform.localScale = (new Vector2(12f, 12f));
        }    


    }

}
