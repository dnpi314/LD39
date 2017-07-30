using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryCan : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Player")
    {
      if (!collision.GetComponent<PlayerController>().canHeld)
      {
        FindObjectOfType<PlayerController>().canHeld = true;
        FindObjectOfType<Fuel>().jerryCanUI.SetActive(true);
        GameController.SpawnCan();
        PickupGas.PlaySound();
        Destroy(gameObject);
      }
    }
  }
}
