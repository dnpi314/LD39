using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
  private static AudioSource gunshotSound;

  private void Start()
  {
    gunshotSound = GetComponent<AudioSource>();
  }

  public static void PlaySound()
  {
    gunshotSound.Play();
  }
}
