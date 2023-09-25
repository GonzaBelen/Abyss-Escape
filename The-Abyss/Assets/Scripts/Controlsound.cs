using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSound : MonoBehaviour
{
    [SerializeField] private GameObject bckgroundMusic1;
    [SerializeField] private GameObject bckgroundMusic2;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {            
            bckgroundMusic1.SetActive(false);
            bckgroundMusic2.SetActive(true);
        }
    }
}
