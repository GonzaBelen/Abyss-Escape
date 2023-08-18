using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirRoca : MonoBehaviour
{
    
    public float radioHit  = 1.15f; 
    public KeyCode buttonHit = KeyCode.E; 

    private void Update()
    {
        if (Input.GetKeyDown(buttonHit))
        {
            VerificarRocaParaDestruir();
        }
    }

    private void VerificarRocaParaDestruir()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radioHit);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Rock"))
            {
                destroyRock(collider.gameObject);
            }
        }
    }

    private void destroyRock(GameObject Rock
        )
    {
       
        Destroy(Rock);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioHit);
    }
}

