using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Counter : MonoBehaviour
{

    public static Counter Instance;

    public float amount;
    

    private void Awake()
    {

        if (Counter.Instance == null)
        {
            Counter.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void AddAmount(float amountEntry){
        amount += amountEntry;
    }
}
