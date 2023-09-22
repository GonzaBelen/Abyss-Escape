using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private GrappleHook grappleHook;

    [SerializeField] private Transform[] respawns;

    [Header("Animation")]
    private Animator animator;



    private void Start()
    {
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
            //Destroy(this.gameObject);
            transform.position = startPoint;
            grappleHook.ResetGrapple();
        }

        if (collider.gameObject.CompareTag("Finish2"))
        {
            //Destroy(this.gameObject);
            startPoint = respawns[1].position;
            transform.position = startPoint;
            grappleHook.ResetGrapple();
        }

        if (collider.gameObject.CompareTag("Finish3"))
        {
            //Destroy(this.gameObject);
            startPoint = respawns[2].position;
            transform.position = startPoint;
            grappleHook.ResetGrapple();
        }

        if (collider.gameObject.CompareTag("Finish4"))
        {
            //Destroy(this.gameObject);
            startPoint = respawns[3].position;
            transform.position = startPoint;
            grappleHook.ResetGrapple();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
            startPoint = respawns[3].position;
            transform.position = startPoint;

            Invoke("Delay", 0.5f);

            grappleHook.ResetGrapple();
        }
    }
    private void Delay()
    {
        this.gameObject.SetActive(true);
    }
}