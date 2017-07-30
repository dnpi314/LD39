using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
  public GameObject startMenu;
  public GameObject tutorial;

  public void Open()
  {
    startMenu.SetActive(false);
    tutorial.SetActive(true);
  }

  public void Close()
  {
    startMenu.SetActive(true);
    tutorial.SetActive(false);
  }
}
