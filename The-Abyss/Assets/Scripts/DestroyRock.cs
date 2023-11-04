using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    
    [SerializeField] private float radioHit  = 1.15f; 
    [SerializeField] private KeyCode buttonHit = KeyCode.Mouse1;
    public static bool pickaxe;
    [SerializeField] private AudioClip rockSound;
    [SerializeField] private AudioClip pickSound;

    private void Start(){
        
        pickaxe = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(buttonHit))
        {
            VerifyRockToDestroy();
            
        }
    }

    private void VerifyRockToDestroy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radioHit);

        

        foreach (Collider2D collider in colliders)
        {
            

            if (collider.CompareTag("Rock"))
            {
                destroyRock(collider.gameObject);
            }

            if (collider.CompareTag("Rock2") && pickaxe == true)
            {
                destroyRock(collider.gameObject);
            }

            if (collider.CompareTag("Rock3") && pickaxe == true)
            {
                destroyRock(collider.gameObject);
            }

            if (collider.CompareTag("Rock4") && pickaxe == true)
            {
                destroyRock(collider.gameObject);
            }
        }
    }

    private void destroyRock(GameObject Rock)
    {
        PlayerSound1.Instance.ExecuteSound(rockSound);
        Destroy(Rock);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioHit);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AccessRock2"))
        {
            PlayerSound1.Instance.ExecuteSound(pickSound);
            pickaxe = true;
            Destroy(collision.gameObject);
        }
    }
}

