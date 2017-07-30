using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGas : MonoBehaviour
{
  static AudioSource sound;

  private void Start()
  {
    sound = GetComponent<AudioSource>();
  }

  public static void PlaySound()
  {
    sound.Play();
  }
}
