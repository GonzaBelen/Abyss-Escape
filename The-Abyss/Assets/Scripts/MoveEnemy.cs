using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float velocity;

    public Transform controlGround;

    public float distance;

    public bool moveRight;

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D informationGround = Physics2D.Raycast(controlGround.position, Vector2.down, distance);
        rb.velocity = new Vector2(velocity, rb.velocity.y);

        if (informationGround == false)
        {
            //girar
            Girar();
        }
    }

    void Girar()
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
