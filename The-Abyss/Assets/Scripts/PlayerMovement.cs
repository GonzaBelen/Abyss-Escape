using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private GrappleHook gh;

    [Header("Movement")]
    [SerializeField] private float movementVelocity;
    [Range(0, 0.3f)] [SerializeField] private float movementSoft;
    private float actualVelocity;
    private float movementHor = 0;
    private Vector3 velocity = Vector3.zero;
    private bool lokingRight = true;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundController;
    [SerializeField] private Vector3 boxDimensions;
    [SerializeField] private bool grounded;
    private float actualJumpForce;
    private bool jump = false; 

    [Header("Run")]
    private bool releasedShiftInAir = false;
    private float runVelocity;
    
    [Header("Respawn")]
    Vector3 startPoint;
    [SerializeField] private Transform[] respawns;
    public static int count;

    private GrappleHook grappleHook;

    [Header("Animation")]
    private Animator animator;

    [Header("Sound")]
   
    //[SerializeField] private GameObject Sound; 
    [SerializeField] private AudioClip jumpSound; 
    //private AudioSource jumpSound;
    [SerializeField]private AudioClip coinSound;

    [Header("EasterEggs")]
    [SerializeField] private GameObject[] coin;
    [SerializeField] private int coins = 0;
    public static bool canUnlock; 

    private void Start()
    {
        count = 0;
        //Sound.SetActive(true);
        canUnlock = false;
        //jumpSound = GetComponent<AudioSource>();
        startPoint = respawns[0].position;
        rb2D = GetComponent<Rigidbody2D>();
        gh = GetComponent<GrappleHook>();
        runVelocity = movementVelocity * 2;
        actualVelocity = movementVelocity;
        actualJumpForce = jumpForce;

        animator = GetComponent<Animator>();

        grappleHook = GetComponent<GrappleHook>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && grounded == true)
        {
            actualVelocity = runVelocity;
            if (jump == true)
            {
                RunJump();   
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (!grounded)
            {
                releasedShiftInAir = true;
            }
            else
            {
                StopRun();
            }
        }

        movementHor = Input.GetAxisRaw("Horizontal") * actualVelocity;

        animator.SetFloat("Horizontal", Mathf.Abs(movementHor));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
             
        }

        if (grounded && releasedShiftInAir)
        {            
            StopRun();
            releasedShiftInAir = false;
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapBox(groundController.position, boxDimensions, 0f, whatIsGround);

        if (!gh.retracting)
        {
            Move(movementHor * Time.fixedDeltaTime, jump);
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }

        jump = false;
    }

    private void Move(float move, bool jump)
    {
        Vector3 objectiveVel = new Vector2(move, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, objectiveVel, ref velocity, movementSoft);
        

        if (move > 0 && !lokingRight)
        {
            Flip();
        }
        else if (move < 0 && lokingRight)
        {
            Flip();
        }

        if (grounded && jump)
        {
            PlayerSound1.Instance.ExecuteSound(jumpSound);  
            grounded = false;
            rb2D.AddForce(new Vector2(0f, actualJumpForce));    
                  
        }
    }

    private void RunJump()
    {
        actualVelocity = runVelocity;
        actualJumpForce = jumpForce * 1.5f;
        rb2D.gravityScale = 4.0f;                
    }

    private void StopRun()
    {
        actualVelocity = movementVelocity;
        actualJumpForce = jumpForce;
        rb2D.gravityScale = 2.35f;
    }

    private void Flip()
    {
        lokingRight = !lokingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundController.position, boxDimensions);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Finish"))
        {           
            transform.position = startPoint;
            grappleHook.ResetGrapple();
        }

        if (collider.gameObject.CompareTag("Finish1"))
        {
            startPoint = respawns[0].position;
            
        }

        if (collider.gameObject.CompareTag("Finish2"))
        {
            startPoint = respawns[1].position;
            
            
            
        }

        if (collider.gameObject.CompareTag("Finish3"))
        {           
            startPoint = respawns[2].position;

         
        }

        if (collider.gameObject.CompareTag("Finish4"))
        {            
            startPoint = respawns[3].position;
          
        }

        if (collider.gameObject.CompareTag("Finish5"))
        {
            startPoint = respawns[6].position;
            
        }

        if (collider.gameObject.CompareTag("Finish6"))
        {
            startPoint = respawns[7].position;
            
        }

        if (collider.gameObject.CompareTag("Finish7"))
        {
            startPoint = respawns[8].position;
            
        }

        if (collider.gameObject.CompareTag("Finish8"))
        {
            startPoint = respawns[9].position;
           
        }


        if (collider.gameObject.CompareTag("Unlock"))
        {            
            startPoint = respawns[4].position;
            transform.position = startPoint;
            
        }

        if (collider.gameObject.CompareTag("Unlock2"))
        {
            startPoint = respawns[5].position;
            transform.position = startPoint;
        }

        if (collider.gameObject.CompareTag("Box"))
        {
           
        }

        if (collider.gameObject.CompareTag("Level1"))
        {
            SceneManager.LoadScene(2);
        }

        if (collider.gameObject.CompareTag("End"))
        {
            
            SceneManager.LoadScene(3);
        }

        if (collider.gameObject.CompareTag("Coin"))
        {
            PlayerSound1.Instance.ExecuteSound(coinSound);
            coins = coins + 1;
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.CompareTag("Key"))
        {
            canUnlock = true;
            Destroy(collider.gameObject);
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
            transform.position = startPoint;
            grappleHook.ResetGrapple();
            Invoke("Delay", 0.5f);
        }

        if (collision.gameObject.CompareTag("SecretWall") && canUnlock)
        {
            collision.gameObject.SetActive(false);
        }    
    }

    private void Delay()
    {
        this.gameObject.SetActive(true);
    }
}