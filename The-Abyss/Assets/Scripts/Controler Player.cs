using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerPlayer : MonoBehaviour
{
    public float hitRadius = 0.5f; // Radio de alcance del golpe
    public LayerMask rockLayer;    // Capa de colisión para las rocas

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Detectar rocas en el radio de golpe
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, hitRadius, rockLayer);

            // Aplicar el golpe a cada roca encontrada
            foreach (Collider2D hit in hits)
            {
                // Destruir la roca
                Destroy(hit.gameObject);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar un gizmo en el editor para visualizar el radio de golpe
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, hitRadius);
    }
}


