using UnityEngine;

public class GameWonState : BaseState
{
  public override void OnActivate()
  {
    Debug.Log("WON");
  }

  public override void OnDeactivate()
  {

  }

}
