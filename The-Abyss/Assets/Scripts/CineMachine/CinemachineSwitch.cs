using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineSwitch : MonoBehaviour
{
    [SerializeField]

    private InputAction action;

    [SerializeField]
    private CinemachineVirtualCamera vcam1; //camara 1

    [SerializeField]
    private CinemachineVirtualCamera vcam2; //camara 2

    private Animation animator;

    private bool camera1 = true;

    private void Awake()
    {
        //animator = GetComponent<Animation>();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
    void Start()
    {
        action.performed += _ => SwitchPriority();
    }
    
    private void SwitchState()
    {
        if (camera1)
        {
            Debug.Log("a");
            animator.Play("Camera2");
        }
        else
        {
            animator.Play("Camera1");

        }
        camera1 = !camera1;
    }
    
    public void SwitchPriority()
    {
         
        vcam1.Priority = 0;
        vcam2.Priority = 1;

    }
    void Update()
    {
       
    }
}
