using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
  private Text scoreDisplay;
  private float score;

  private void OnEnable()
  {
    scoreDisplay = GetComponent<Text>();
    score = FindObjectOfType<Score>().GetScore();
  }

  private void Update()
  {
    if (Mathf.FloorToInt(score % 60) < 10)
    {
      scoreDisplay.text = string.Format("Time Survived \n{0}:0{1}", Mathf.FloorToInt(score / 60), Mathf.FloorToInt(score % 60));
    }
    else
    {
      scoreDisplay.text = string.Format("Time Survived \n{0}:{1}", Mathf.FloorToInt(score / 60), Mathf.FloorToInt(score % 60));
    }
  }
}
