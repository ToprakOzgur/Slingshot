using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ResetState : BaseState
{
  public static event Action OnGamePlayActivated = delegate { };
  public override void OnActivate()
  {
    OnGamePlayActivated();
  }

  public override void OnDeactivate()
  {
    throw new System.NotImplementedException();
  }

  public override void OnUpdate()
  {
    throw new System.NotImplementedException();
  }
}