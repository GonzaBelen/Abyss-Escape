using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    [SerializeField] private GameObject objects;
    public bool activator = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            objects.SetActive(true);
            activator = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            objects.SetActive(false);
            activator = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && activator)
        {
            SceneManager.LoadScene(7);
        }
    }

}
