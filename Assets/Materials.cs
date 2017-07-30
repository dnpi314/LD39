using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
  public int amount;
  public float lifespan;

  private void Update()
  {
    lifespan -= Time.deltaTime;
    if(lifespan <= 0)
    {
      Destroy(gameObject);
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Player")
    {
      collision.GetComponent<PlayerController>().materials += amount;
      Pickup.PlaySound();
      Destroy(gameObject); 
    }
  }
}
