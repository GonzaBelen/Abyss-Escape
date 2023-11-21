using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRooms : MonoBehaviour
{
    [SerializeField] private AudioClip secretSound;
    public int door;
    void Start()
    {
        door = 1;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && door == 1)
        {
            PlayerSound1.Instance.ExecuteSound(secretSound);
            door = 0;
        }
    }

    void Update()
    {
        
    }
}
