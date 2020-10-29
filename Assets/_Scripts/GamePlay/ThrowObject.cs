using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
  public static event Action OnLaunched = delegate { };
  public static event Action<Vector3, Vector3> OnDrag = delegate { };
  protected float mZCoord;
  protected Vector3 touchStartPoint;


  #region Drag functions
  protected void OnMouseDown()
  {
    mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

    touchStartPoint = GetMouseWorldPos();

  }
  protected void OnMouseUp()
  {
    OnLaunched();
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
    OnDrag(worldPos, touchStartPoint);
  }

  #endregion
}
