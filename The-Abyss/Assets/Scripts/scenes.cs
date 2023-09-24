using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scenes : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;
    [SerializeField] private GameObject[] changePoint;
   
    

    void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);

            changePoint[0].SetActive(false);
            changePoint[1].SetActive(true);

         
        }

    }
  
}
