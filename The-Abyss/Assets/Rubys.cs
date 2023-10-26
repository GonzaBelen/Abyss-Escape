using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubys : MonoBehaviour
{
    [SerializeField] private AudioClip rubySound;

    private int rubys;

    [SerializeField] private float amount;

    [SerializeField] private Counter counter;
    [SerializeField] private GameObject image;
    private bool state;

    void Start()
    {
        state = false;
    }

    private void OnTriggerEnter2D(Collider2D collider){

          if (collider.gameObject.CompareTag("Player"))
        {
            image.SetActive(true);
            state = true;

            counter.AddAmount(amount);

            PlayerSound1.Instance.ExecuteSound(rubySound);
            rubys = rubys + 1;
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if(state == true){ 

        Invoke("Delay", 1);
        }
    }

    private void Delay()
    {
        image.SetActive(false);
    }

    
 
}
