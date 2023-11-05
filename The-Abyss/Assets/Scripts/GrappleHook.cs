using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    LineRenderer line;

    [SerializeField] LayerMask grapplableMask;
   

    [SerializeField] private AudioClip grappleSound;

    [SerializeField] float maxDistance = 6f;
    [SerializeField] float grappleSpeed = 10f;
    [SerializeField] float grappleShootSpeed = 20f;

    [HideInInspector] public bool retracting = false;
    [HideInInspector] public bool isGrappling = false;

    Vector2 target;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && !isGrappling)
        {
            StartGrapple();
        }

        if (retracting)
        {
            Vector2 grapplePos = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);

            transform.position = grapplePos;

            line.SetPosition(0, transform.position);

            if (Vector2.Distance(transform.position, target) < 0.5f)
            {
                //ResetGrapple();
                Invoke("ResetGrapple", 0.2f);
            }
        }
       
    }

    private void StartGrapple()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, maxDistance, grapplableMask);
        //Debug.DrawRay(transform.position, direction * maxDistance, Color.red);

        if (hit2D.collider != null && hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Grapplable"))
        {
            PlayerSound1.Instance.ExecuteSound(grappleSound);
            isGrappling = true;
            target = hit2D.point;
            line.enabled = true;
            line.positionCount = 2;

            Grapple();

        }
    }

    void Grapple()
    {
        

        float t = 0;
        float time = 10;

        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position);

        Vector2 newPos;

        for(; t < time; t += grappleShootSpeed * Time.deltaTime)
        {
            newPos = Vector2.Lerp(transform.position, target, t / time);
            line.SetPosition(0, transform.position);
            line.SetPosition(1, newPos);
        }

        line.SetPosition(1, target);
        retracting = true;
    }

    public void ResetGrapple()
    {
        retracting = false;
        isGrappling = false;
        line.enabled = false;
    }
}
