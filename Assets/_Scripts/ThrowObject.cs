using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{

  protected float mZCoord;
  protected Sling sling;
  protected Vector3 touchStartPoint;


  #region Unity functions

  protected void Awake()
  {
    sling = transform.parent.parent.gameObject.GetComponent<Sling>();
  }

  #endregion

  #region Drag functions
  protected void OnMouseDown()
  {
    mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

    touchStartPoint = GetMouseWorldPos();

  }

  protected void OnMouseUp()
  {
    sling.Launch();
    sling.VibrationAnimToOriginalPosAfterLaunch();
    touchStartPoint = Vector3.zero;
  }
  protected Vector3 GetMouseWorldPos()
  {
    var mousePoint = Input.mousePosition;
    mousePoint.z = mZCoord;

    return Camera.main.ScreenToWorldPoint(mousePoint);
  }
  protected void OnMouseDrag()
  {
    var worldPos = GetMouseWorldPos();

    sling.Bend(worldPos, touchStartPoint);
  }

  #endregion
}
