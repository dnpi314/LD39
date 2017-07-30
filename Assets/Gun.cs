using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  public string gunName;
  public float damage;
  public float rateOfFire;
  public bool isAutomatic;
  public int clipSize;
  public int currentClip;
  public float reloadTime;
  public bool isRifle;
}
