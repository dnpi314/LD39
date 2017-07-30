using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
  private AudioSource sound;

  private void Start()
  {
    sound = GetComponent<AudioSource>();
  }

  public void ToggleSound()
  {
    if (!sound.mute)
      sound.mute = true;
    else
      sound.mute = false;
  }
}
