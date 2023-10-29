using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRubys: MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = Counter.Instance.amount.ToString("0");
    }
}
