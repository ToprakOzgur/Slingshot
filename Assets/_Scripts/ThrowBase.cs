using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThrowBase : MonoBehaviour
{
   private Vector3 mOffset;
private float mZCoord;

  public void OnMouseDown()
  {
    Debug.Log("mouse down");


    mZCoord=Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

    mOffset=gameObject.transform.position-GetMouseWorldPos();
  }

  public void OnMouseUp()
  {
    Debug.Log("mouse up");
  }



  private Vector3 GetMouseWorldPos()
  {
    Vector3 mousePoint = Input.mousePosition; 
    mousePoint.z=mZCoord;
    return Camera.main.ScreenToWorldPoint(mousePoint);
  }
  public void OnMouseDrag() 
  { 
    transform.position=GetMouseWorldPos() + mOffset;
  
  }
}
