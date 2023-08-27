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
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
        
            cameras[0].SetActive(false);
            cameras[1].SetActive(true);

            Invoke("Delay", 1);
        }

    }

    private void Delay()
    {
        changePoint[0].SetActive(false);
        changePoint[1].SetActive(true);
    }
}
