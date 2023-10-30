using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors1 : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    public bool activator = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            objects[0].SetActive(true);
            activator = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            objects[0].SetActive(false);
            activator = false;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Counter.Instance.amount == 6 && activator)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown(KeyCode.E) && Counter.Instance.amount < 6 && activator)
        {
            objects[1].SetActive(true);
            Invoke("Delay", 2f);
        }
    }

    private void Delay()
    {
        objects[1].SetActive(false);
    }
}
