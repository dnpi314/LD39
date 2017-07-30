using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMaterials : MonoBehaviour
{
  private Text materialsDisplay;

  public PlayerController player;

  private void Start()
  {
    materialsDisplay = GetComponent<Text>();
  }

  private void Update()
  {
    materialsDisplay.text = string.Format("Materials: {0}", player.materials);
  }
}
