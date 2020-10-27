using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBase : MonoBehaviour
{
  protected Vector3 mOffset;
  protected float mZCoord;

  protected void OnMouseDown()
  {
    Debug.Log("mouse down");


    mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

    mOffset = gameObject.transform.position - GetMouseWorldPos();
  }

  protected void OnMouseUp()
  {
    Debug.Log("mouse up");
  }



  protected Vector3 GetMouseWorldPos()
  {
    Vector3 mousePoint = Input.mousePosition;
    mousePoint.z = mZCoord;
    return Camera.main.ScreenToWorldPoint(mousePoint);
  }
  protected void OnMouseDrag()
  {
    transform.position = GetMouseWorldPos() + mOffset;

  }
}
