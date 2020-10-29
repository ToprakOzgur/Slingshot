using System.Linq;
using UnityEngine;

public class Game
{
  private readonly int shotCount = 5;
  private readonly int successCount = 3;

  private int currentShot;
  private Shot[] shoots;
  public Game()
  {
    shoots = new Shot[shotCount];
    currentShot = 0;
  }
  public void ShotIsSuccessful()
  {
    Debug.Log("success");
    shoots[currentShot].isSuccess = true;

    Managers.Score.AddScore(shoots[currentShot].score + 1);

    if (didWin())
    {
      Managers.Game.SetState(typeof(GameWonState));
      return;
    }

    //add next shot score bonus
    shoots[currentShot + 1].score += shoots[currentShot].score + 1;
    currentShot++;
  }

  public void ShotIsFail()
  {
    Debug.Log("fail");
    shoots[currentShot].isSuccess = false;
    currentShot++;

    if (didLost())
    {
      Managers.Game.SetState(typeof(GameLostState));
      return;
    }

    shoots[currentShot].score = 0;
  }

  public bool didWin() => shoots.Where(x => x.isSuccess == true).ToList().Count >= successCount;
  public bool didLost() => currentShot >= shotCount;

}
