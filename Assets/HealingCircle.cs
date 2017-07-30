using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingCircle : MonoBehaviour
{
  public float healingRate;
  public bool healingPlayer;
  float healTimer = 0;
  public PlayerController player;

  private void Update()
  {
    if(player.health >= 100)
    {
      return;
    }
    if (healingPlayer)
    {
      healTimer += Time.deltaTime;
      if(healTimer >= healingRate)
      {
        player.health++;
        healTimer = 0;
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Player")
    {
      healingPlayer = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if(collision.tag == "Player")
    {
      healingPlayer = false;
    }
  }
}
