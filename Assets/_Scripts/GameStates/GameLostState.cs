using System;
using UnityEngine;

public class GameLostState : BaseState
{

  public override void OnActivate()
  {
    Debug.Log("lost");
    Managers.UI.EnableMenuPanel();
    Managers.UI.DisableStartButton();
    Managers.UI.EnableRestartButton();
    Managers.UI.EnableScoreText();
    Managers.UI.EnableLostText();

  }

  public override void OnDeactivate()
  {
    Managers.UI.DisableMenuPanel();
    Managers.UI.DisableStartButton();
    Managers.UI.DisableScoreText();
    Managers.UI.DisableLostText();
  }


}
