using UnityEngine;

public class GameWonState : BaseState
{
  public override void OnActivate()
  {
    Debug.Log("WON");
    Managers.UI.EnableMenuPanel();
    Managers.UI.DisableStartButton();
    Managers.UI.EnableRestartButton();
  }

  public override void OnDeactivate()
  {

  }

}
