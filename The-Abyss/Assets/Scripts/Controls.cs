using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
   
    [SerializeField] private GameObject[] controls;
   
    void Start()
    {
  
    }

    private void Update()
    {
    

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
   

        if (collider.gameObject.CompareTag("Box Move"))
        {
            Destroy(controls[0]);
            Destroy(collider);
            controls[1].SetActive(true);
        }

        if (collider.gameObject.CompareTag("Box Jump"))
        {
            Destroy(controls[1]);
            Destroy(collider);
            controls[2].SetActive(true);
        }

        if (collider.gameObject.CompareTag("Box Run"))
        {
            Destroy(controls[2]);
            Destroy(collider);

        }

        if (collider.gameObject.CompareTag("Box Rock2"))
        {
            controls[3].SetActive(true);
            Destroy(collider);
        }

        if (collider.gameObject.CompareTag("Box Rock"))
        {
            Destroy(controls[3]);
            Destroy(collider);
            controls[4].SetActive(true);
        }

        if (collider.gameObject.CompareTag("Box Grapple"))
        {
            Destroy(controls[4]);
            Destroy(collider);
        }

    }
}
