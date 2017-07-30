using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLayerOrder : MonoBehaviour
{
  private SpriteRenderer sprite;

  public Transform player;

  private void Start()
  {
    sprite = GetComponent<SpriteRenderer>();
  }

  private void Update()
  {
    if(transform.position.y > player.position.y)
    {
      sprite.sortingOrder = -5;
    }
    else
    {
      sprite.sortingOrder = 5;
    }
  }
}
