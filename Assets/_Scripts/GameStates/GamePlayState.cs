using UnityEngine;

public class GamePlayState : BaseState
{
  private Game currentGame;

  public override void OnActivate()
  {
    ThrowObject.isGamePlayActivated = true;

    currentGame = new Game();
  }
  public override void OnDeactivate()
  {
    ThrowObject.isGamePlayActivated = false;
  }
  private void OnEnable()
  {
    WinTrigger.OnSuccess += ShotSuccess;
    LostTrigger.OnFail += ShotFail;
  }
  private void OnDisable()
  {
    WinTrigger.OnSuccess -= ShotSuccess;
    LostTrigger.OnFail -= ShotFail;
  }
  private void ShotSuccess()
  {
    currentGame.ShotIsSuccessful();
  }
  private void ShotFail()
  {
    currentGame.ShotIsFail();
  }

}
