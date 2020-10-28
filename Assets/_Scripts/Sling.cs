using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{
  #region Edges

  [System.Serializable]
  public struct Edges
  {
    public Transform left;
    public Transform right;

  }
  public Edges edgeTransforms;

  #endregion

  #region properties
  private float maxBindAngle = 30;
  private int bindSensibility = 30;
  private float bounceOutAnimDuration = 0.6f;

  #endregion



  #region functions

  //Rotation of Sling when targeting
  public void Bend(float endDragPos, float startDragPos)
  {
    var dragMagnitude = startDragPos - endDragPos;

    if (dragMagnitude < 0) return;

    var bindMagnitude = dragMagnitude * bindSensibility;

    //clamping max value to maxBindAngle
    var angleClamped = bindMagnitude > maxBindAngle ? maxBindAngle : bindMagnitude;

    transform.eulerAngles = new Vector3(-angleClamped, transform.eulerAngles.y, transform.eulerAngles.z);
  }

  public void VibrationAnimToOriginalPosAfterLaunch()
  {
    StartCoroutine(Move());
  }
  IEnumerator Move()
  {
    Vector3 startPosition = transform.position;
    Quaternion startRotation = transform.rotation;

    var t = 0f;
    while (t < 1)
    {
      t += Time.deltaTime / bounceOutAnimDuration;
      transform.rotation = Quaternion.Lerp(startRotation, Quaternion.identity, Ease.BounceEaseOut(t));
      yield return null;
    }
  }


  #endregion
}



