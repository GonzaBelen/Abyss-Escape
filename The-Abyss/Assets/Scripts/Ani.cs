using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactiveAni : MonoBehaviour
{
    [SerializeField] private GameObject animator;

    void Start()
    {
        
    }
    public void StopAni()
    {
        animator.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            StopAni();


        }
    }
}
