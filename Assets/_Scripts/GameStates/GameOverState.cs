using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : BaseState
{
  public static event Action OnPlayerDied = delegate { };
  public override void OnActivate()
  {
    OnPlayerDied();
    PlayerPrefs.Save();
    // StartCoroutine(ExtraScoreTimeAfterDied());
    // StartCoroutine(FadeCameraColor());


  }

  public override void OnDeactivate()
  {

  }

  public override void OnUpdate()
  {

  }

  //   private IEnumerator ExtraScoreTimeAfterDied()
  //   {
  //     Managers.UI.lastCallText.SetActive(true);
  //     yield return new WaitForSeconds(3);
  //     Managers.Game.isGameplayActive = false;
  //     yield return new WaitForSeconds(1);
  //     ReloadCurrentScene();
  //   }

  //   private IEnumerator FadeCameraColor()
  //   {
  //     float t = 0;
  //     float duration = 0.5f;

  //     var startColor = Camera.main.backgroundColor;
  //     var endColor = Color.black;

  //     while (t < 1)
  //     {
  //       t += Time.deltaTime * 1 / duration;
  //       Camera.main.backgroundColor = Color.Lerp(startColor, endColor, t);
  //       yield return null;
  //     }
  //   }

}
