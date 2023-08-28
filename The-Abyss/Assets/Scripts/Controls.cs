using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
   
    [SerializeField] private GameObject[] controls;
    [SerializeField] private bool camera2;

    void Start()
    {
        camera2 = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A) && controls[0] == true || Input.GetKeyUp(KeyCode.D) && controls[0] == true)
        {
            Destroy(controls[0]);
            controls[1].SetActive(true);
        }

        if (Input.GetButtonDown("Jump") && controls[1] == true)
        {
            Destroy(controls[1]);
            controls[2].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && controls[2] == true)
        {
            Destroy(controls[2]);
        }

        if (camera2 == true)
        {
            controls[3].SetActive(true);
            camera2 = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && controls[3] == true)
        {
            Destroy(controls[3]);
            controls[4].SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && controls[4] == true)
        {
            Destroy(controls[4]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Box"))
        {
            camera2 = true;
        }

    }
}
