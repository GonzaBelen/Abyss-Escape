using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaceArea : MonoBehaviour
{
    [SerializeField] private GameObject[] peace;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {

            peace[0].SetActive(false);
            Invoke("Delay", 0.75f);

        }

    }

    private void Delay()
    {
        peace[1].SetActive(true);
    }

 
}
