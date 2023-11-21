using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour
{
    
    [SerializeField] private GameObject[] changePoint;
    private CinemachineSwitch cine;
    void Awake()
    {
        cine = GetComponent<CinemachineSwitch>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {

            cine.SwitchPriority();

            changePoint[0].SetActive(false);
            changePoint[1].SetActive(true);

         
        }

    }
  
}
