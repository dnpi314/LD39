using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
  public GameObject openMenuIndicator;
  public GameObject craftingMenu;
  public Transform player;

  private bool isNearBench;
  private bool isMenuOpen;

  private void Update()
  {
    if((player.position - transform.position).magnitude <= 4f && !isNearBench)
    {
      isNearBench = true;
      openMenuIndicator.SetActive(true);
    }
    else if(isNearBench && (player.position - transform.position).magnitude > 4f)
    {
      isNearBench = false;
      openMenuIndicator.SetActive(false);
      if (isMenuOpen)
      {
        craftingMenu.SetActive(false);
        isMenuOpen = false;
      }
    }

    if (isNearBench && Input.GetKeyDown(KeyCode.E))
    {
      if (isMenuOpen)
      {
        craftingMenu.SetActive(false);
        isMenuOpen = false;
      }
      else
      {
        craftingMenu.SetActive(true);
        isMenuOpen = true;
      }
    }
  }
}
