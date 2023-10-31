using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
  
    private void Start()
    {
       
    }
  
    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        SceneManager.LoadScene(1);
    }
}
