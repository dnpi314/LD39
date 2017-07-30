﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour
{
  public float lifespan;
  float timer;

  private void OnEnable()
  {
    timer = lifespan;
  }

  private void Update()
  {
    timer -= Time.deltaTime;
    if(timer <= 0)
    {
      gameObject.SetActive(false);
    }
  }
}
