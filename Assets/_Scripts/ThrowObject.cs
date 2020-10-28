using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
  protected Vector3 mOffset;
  protected float mZCoord;
  protected Sling sling;
  protected Vector3 touchStartPoint;


  #region Unity functions

  protected void Awake()
  {
    sling = transform.parent.gameObject.GetComponent<Sling>();
  }

  #endregion

  #region Drag functions
  protected void OnMouseDown()
  {
    mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

    touchStartPoint = GetMouseWorldPos();
    mOffset = gameObject.transform.position - touchStartPoint;
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

    //for ball movement left-right
    var newPos = worldPos + mOffset;
    newPos.x = Mathf.Clamp(newPos.x, sling.edgeTransforms.left.position.x, sling.edgeTransforms.right.position.x);

    //for sling angle
    sling.Bend(worldPos.y, touchStartPoint.y);
    transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);



  }



  #endregion
}
