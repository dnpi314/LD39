using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
  private Text healthDisplay;

  public PlayerController player;

  private void Start()
  {
    healthDisplay = GetComponent<Text>();
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
  }

  private void Update()
  {
    healthDisplay.text = string.Format("Health: {0}", player.health);
  }
}
