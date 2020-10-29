using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : BaseButton
{
  public override void OnButtonPressed()
  {
    Managers.Game.SetState(typeof(GamePlayState));
  }
}
