using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    private float amount;
    private TextMeshProUGUI textMesh;
    
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

   
    private void Update()
    {
        textMesh.text = amount.ToString("0");
    }

    public void AddAmount(float amountEntry){
        amount += amountEntry;
    }
}
