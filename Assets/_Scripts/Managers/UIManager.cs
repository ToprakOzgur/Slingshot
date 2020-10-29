using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
  [SerializeField] private GameObject uiPanel;
  [SerializeField] private GameObject startButton;
  [SerializeField] private GameObject restartButton;

  public void EnableMenuPanel() => uiPanel.SetActive(true);
  public void DisableMenuPanel() => uiPanel.SetActive(false);
  public void EnableStartButton() => startButton.SetActive(true);
  public void DisableStartButton() => startButton.SetActive(false);
  public void EnableRestartButton() => restartButton.SetActive(true);
  public void DisableRestartButton() => restartButton.SetActive(false);



}
