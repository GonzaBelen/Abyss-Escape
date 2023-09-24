using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    
    [SerializeField] private float radioHit  = 1.15f; 
    [SerializeField] private KeyCode buttonHit = KeyCode.E;
    private bool pickaxe;

    private void Update()
    {
        if (Input.GetKeyDown(buttonHit))
        {
            VerifyRockToDestroy();
            
        }
    }

    private void VerifyRockToDestroy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radioHit);

        

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Rock"))
            {
                destroyRock(collider.gameObject);
            }

            if (collider.CompareTag("Rock2") && pickaxe == true)
            {
                destroyRock(collider.gameObject);
            }
        }
    }

    private void destroyRock(GameObject Rock)
    {       
        Destroy(Rock);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioHit);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AccessRock2"))
        {
            pickaxe = true;
            Destroy(collision);
        }
    }
}

