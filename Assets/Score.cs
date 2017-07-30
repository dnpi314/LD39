using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
  private Text scoreDisplay;
  private float score = 0;

  private void Start()
  {
    scoreDisplay = GetComponent<Text>();
  }

  private void Update()
  {
    score += Time.deltaTime;
    if(Mathf.FloorToInt(score % 60) < 10)
    {
      scoreDisplay.text = string.Format("Time Survived {0}:0{1}", Mathf.FloorToInt(score / 60), Mathf.FloorToInt(score % 60));
    }
    else
    {
      scoreDisplay.text = string.Format("Time Survived {0}:{1}", Mathf.FloorToInt(score / 60), Mathf.FloorToInt(score % 60));
    }
  }

  public float GetScore()
  {
    return score;
  }
}
