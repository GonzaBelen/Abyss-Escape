using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls2 : MonoBehaviour
{
   
    [SerializeField] private GameObject[] controls;
   
    void Start()
    {
  
    }

    private void Update()
    {
    

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
   

        if (collision.gameObject.CompareTag("Rock2") && DestroyRock.pickaxe == false)
        {
            controls[0].SetActive(true);
        }

        if (collision.gameObject.CompareTag("Rock3") && DestroyRock.pickaxe == false)
        {
            controls[1].SetActive(true);
        }

        if (collision.gameObject.CompareTag("Rock4") && DestroyRock.pickaxe == false)
        {
            controls[2].SetActive(true);
        }

        if (collision.gameObject.CompareTag("SecretWall") && PlayerMovement.canUnlock == false)
        {
            controls[3].SetActive(true);
        }


        if (collision.gameObject.CompareTag("Rock3") && DestroyRock.pickaxe == true)
        {
            controls[4].SetActive(true);
        }

        if (collision.gameObject.CompareTag("Rock4") && DestroyRock.pickaxe == true)
        {
            controls[5].SetActive(true);
        }

     

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock2"))
        {
            controls[0].SetActive(false);
        }

        if (collision.gameObject.CompareTag("Rock3"))
        {
            controls[1].SetActive(false);
        }

        if (collision.gameObject.CompareTag("Rock4"))
        {
            controls[2].SetActive(false);
        }

        if (collision.gameObject.CompareTag("SecretWall"))
        {
            controls[3].SetActive(false);
        }

        if (collision.gameObject.CompareTag("Rock3"))
        {
            controls[4].SetActive(false);
        }

        if (collision.gameObject.CompareTag("Rock4"))
        {
            controls[5].SetActive(false);
        }

      
    }
}
