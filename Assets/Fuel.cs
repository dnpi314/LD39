using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
  private Text fuelDisplay;

  public float fuel;
  public GameObject jerryCanUI;

  private void Start()
  {
    fuel = 60;
    fuelDisplay = GetComponent<Text>();
  }

  private void Update()
  {
    fuel -= Time.deltaTime;
    if(fuel <= 0)
    {
      GameController.GameOver();
    }
    fuelDisplay.text = string.Format("Fuel: {0}", (int)fuel);
  }
}
