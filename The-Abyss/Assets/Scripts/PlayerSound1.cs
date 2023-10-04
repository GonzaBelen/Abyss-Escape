using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound1 : MonoBehaviour
{
  private AudioSource audioSource;
  public static PlayerSound1 Instance;
  


  private void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  
    private void Awake(){

        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void ExecuteSound(AudioClip sonido){
        audioSource.PlayOneShot(sonido);
    }
}
