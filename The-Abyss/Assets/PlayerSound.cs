using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
  private AudioSource audioSource;

  [SerializeField] private AudioClip SoundJump;


  private void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  private void JUMP(){
    if(Input.GetButtonDown("Jump"))
    {
        audioSource.PlayOneShot(SoundJump);
    } 
  }
}
