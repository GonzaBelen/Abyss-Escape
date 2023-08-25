using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movement")]
    [SerializeField] private float movementVelocity;
    [Range(0, 0.3f)][SerializeField] private float movementSoft;
    private float movementHor = 0;
    private Vector3 velocity = Vector3.zero;
    private bool lokingRight = true;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundController;
    [SerializeField] private Vector3 boxDimensions;
    [SerializeField] private bool grounded;
    private bool jump = false;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementHor = Input.GetAxisRaw("Horizontal") * movementVelocity;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapBox(groundController.position, boxDimensions, 0f, whatIsGround);
        
        Move(movementHor * Time.fixedDeltaTime, jump);

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
            rb2D.AddForce(new Vector2(0f, jumpForce));
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