using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubys : MonoBehaviour
{
    [SerializeField] private AudioClip rubySound;

    private int rubys;

    [SerializeField] private float amount;

    [SerializeField] private Counter counter;
    [SerializeField] public GameObject image;


    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collider){

          if (collider.gameObject.CompareTag("Player"))
        {
            image.SetActive(true);

            counter.AddAmount(amount);

            PlayerSound1.Instance.ExecuteSound(rubySound);
            rubys = rubys + 1;

            Destroy(this.gameObject);
            
        }
    }

    private void Update()
    {
       
    }

    public void Destroy(){
        
         image.SetActive(false);

    }
    
 
}
