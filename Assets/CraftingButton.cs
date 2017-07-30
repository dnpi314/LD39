using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingButton : MonoBehaviour
{
  public string gunName;
  public Crafting craftingBench;
  public PlayerController player;
  public int cost;
  public bool purchased = false;

  private Text purchaseText;

  private void Start()
  {
    purchaseText = GetComponentInChildren<Text>();
  }

  private void Update()
  {
    if (purchased)
    {
      purchaseText.text = "Equip";
    }
    else
    {
      purchaseText.text = "" + cost;
    }
  }

  public void Equip()
  {
    if (purchased)
    {
      player.Equip(gunName);
      return;
    }
    else
    {
      if(player.materials >= cost)
      {
        player.materials -= cost;
        purchased = true;
        player.Equip(gunName);
      }
    }
  }
}
