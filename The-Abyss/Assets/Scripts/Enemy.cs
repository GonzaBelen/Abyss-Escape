using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
  
    [Header("Movement")]
        [SerializeField] private float velocity;
        [SerializeField] private float distance;
        [SerializeField] private bool moveRight;

    [Header("Hit")]
        [SerializeField] private int damage;

    [Header("Ground")]
        [SerializeField] private Transform controlGround;
        [SerializeField] private LayerMask groundMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D informationGround = Physics2D.Raycast(controlGround.position, Vector2.down, distance, groundMask);
        rb.velocity = new Vector2(velocity, rb.velocity.y);

        if (informationGround == false)
        {
    
            Flip();
        }
    }

    void Flip()
    {
        moveRight = !moveRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocity *= -1;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controlGround.transform.position, controlGround.transform.position + Vector3.down * distance);
    }

}
