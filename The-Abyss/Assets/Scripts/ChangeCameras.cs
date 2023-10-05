using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour
{ 
    Vector3 startPoint2;
    [SerializeField] private Transform[] respawns2;

    private void Start()
    {
        startPoint2 = respawns2[0].position;
    }

    private void Update()
    {
        if (PlayerMovement.count == 1)
        {
            startPoint2 = respawns2[1].position;
            transform.position = startPoint2;
        }
    }

}
