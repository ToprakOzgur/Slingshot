using System;
using UnityEngine;

public class GameLostState : BaseState
{
  public static event Action OnPlayerDied = delegate { };
  public override void OnActivate()
  {
    Debug.Log("lost");
    OnPlayerDied();
  }

  public override void OnDeactivate()
  {

  }


}
