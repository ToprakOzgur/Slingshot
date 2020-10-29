using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLostState : BaseState
{
  public static event Action OnPlayerDied = delegate { };
  public override void OnActivate()
  {
    OnPlayerDied();
  }

  public override void OnDeactivate()
  {

  }


}
