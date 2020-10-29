using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  private int currentScore = 0;

  public void AddScore(int amount)
  {
    currentScore += amount;
    Debug.Log("Score: " + currentScore);
  }
}
