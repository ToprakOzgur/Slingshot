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
  }

  public override void OnDeactivate()
  {

  }


}
