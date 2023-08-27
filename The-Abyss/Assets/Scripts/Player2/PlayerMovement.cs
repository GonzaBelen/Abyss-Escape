using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private GrappleHook gh;

    [Header("Movement")]
    [SerializeField] private float movementVelocity;
    [Range(0, 0.3f)][SerializeField] private float movementSoft;
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
    private float runVelocity;
    //private bool isRunning = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gh = GetComponent<GrappleHook>();
        runVelocity = movementVelocity * 2;
        actualVelocity = movementVelocity;
        actualJumpForce = jumpForce;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            actualVelocity = runVelocity;
            actualJumpForce = jumpForce * 1.5f;
            rb2D.gravityScale = 4.0f;
        }
        if (Input.GetKeyUp(KeyCode.K)) 
        {
            actualVelocity = movementVelocity;
            actualJumpForce = jumpForce;
            rb2D.gravityScale = 2.35f;
        }

        movementHor = Input.GetAxisRaw("Horizontal") * actualVelocity;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapBox(groundController.position, boxDimensions, 0f, whatIsGround);

        if (!gh.retracting){

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

        if (move > 0 && !lokingRight){
            Flip();
        }
        else if (move <0 && lokingRight){
            Flip();
        }

        if (grounded && jump){
            grounded = false;
            rb2D.AddForce(new Vector2(0f, actualJumpForce));
        }
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

  
}