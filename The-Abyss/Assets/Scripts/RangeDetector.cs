using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    [SerializeField] private Color normalColor = Color.blue;
    [SerializeField] private Color normalColor2 = Color.red;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HookRadio"))
        {
            spriteRenderer.color = normalColor;
            Debug.Log("entro");
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HookRadio"))
        {
            spriteRenderer.color = normalColor2;
            Debug.Log("salio");
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
