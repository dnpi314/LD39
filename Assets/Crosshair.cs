using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
  private void Update()
  {
    var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    pos.z = 0;
    transform.position = pos;
  }
}
