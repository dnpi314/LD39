using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
  private Text ammoDisplay;

  public PlayerController player;

  private void Start()
  {
    ammoDisplay = GetComponent<Text>();
  }

  private void Update()
  {
      ammoDisplay.text = string.Format("Ammo: {0}", player.heldGun.currentClip);
  }
}
