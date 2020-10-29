using UnityEngine;

public class GameWonState : BaseState
{
  public override void OnActivate()
  {
    Debug.Log("WON");
    Managers.UI.EnableMenuPanel();
    Managers.UI.DisableStartButton();
    Managers.UI.EnableRestartButton();
    Managers.UI.EnableScoreText();
    Managers.UI.EnableWinText();
  }

  public override void OnDeactivate()
  {
    Managers.UI.DisableMenuPanel();
    Managers.UI.DisableStartButton();
    Managers.UI.DisableScoreText();
    Managers.UI.DisableWinText();
  }

}
