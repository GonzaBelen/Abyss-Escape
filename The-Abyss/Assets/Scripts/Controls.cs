using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject[] director;
   
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
            director[0].SetActive(true);
            Destroy(controls[0]);
            Destroy(collider);
            
            //controls[1].SetActive(true);
        }

        if (collider.gameObject.CompareTag("Box Jump"))
        {
            director[1].SetActive(true);
            Destroy(controls[1]);
            Destroy(collider);
            //controls[2].SetActive(true);
        }

        if (collider.gameObject.CompareTag("Box Run"))
        {
            director[2].SetActive(true);
            Destroy(controls[2]);
            Destroy(collider);

        }

        if (collider.gameObject.CompareTag("Box Rock2"))
        {
            director[5].SetActive(true);
            Destroy(controls[4]);
            //controls[3].SetActive(true);
            Destroy(collider);
        }

        if (collider.gameObject.CompareTag("Box Rock"))
        {
            director[3].SetActive(true);
            
            Destroy(collider);
            //controls[4].SetActive(true);
        }

        if (collider.gameObject.CompareTag("Box Grapple"))
        {
            director[4].SetActive(true);
            Destroy(controls[3]);
            Destroy(collider);
        }

    }
}
