using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float velocity;
    [SerializeField] private float distance;
    [SerializeField] private bool moveUp;

    [Header("Hit")]
    [SerializeField] private int damage;

    [Header("Ground")]
    [SerializeField] private Transform controlAir;
    private bool hasFliped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D informationAir = Physics2D.Raycast(controlAir.position, Vector2.left, distance);
        rb.velocity = new Vector2(rb.velocity.x, velocity);

        if (informationAir == false)
        {

            Flip();
        }

        if (hasFliped == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }
        else
        {
            transform.eulerAngles = new Vector3(180, 0, 0);
        }
    }

    void Flip()
    {
        moveUp = !moveUp;
        velocity *= -1;
        hasFliped = !hasFliped;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controlAir.transform.position, controlAir.transform.position + Vector3.left * distance);
    }

}
