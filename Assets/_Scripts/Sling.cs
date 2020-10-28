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
  [SerializeField] private List<ThrowObject> throwObjects;

  [Header("GamePlay Settings")]
  [SerializeField] [Range(0, 30)] private int maxBindAngleVertical;
  [SerializeField] [Range(0, 60)] private int maxBindAngleHorizontal;
  [SerializeField] private int bindSensibility;
  [SerializeField] private float bounceOutAnimDuration;

  #endregion

  #region Unity functions
  private void Awake()
  {

  }
  #endregion


  #region functions

  public void Launch()
  {
    throwObjects[0].gameObject.transform.parent = null;
    throwObjects[0].gameObject.GetComponent<Rigidbody>().isKinematic = false;
    throwObjects[0].gameObject.GetComponent<Rigidbody>().velocity = throwObjects[0].gameObject.transform.forward * 20;
  }

  //Rotation of Sling when targeting
  public void Bend(Vector3 endDragPos, Vector3 startDragPos)
  {
    var dragVertical = startDragPos.y - endDragPos.y;
    var dragHorizontal = startDragPos.x - endDragPos.x;

    if (dragVertical < 0) return;

    var bindVertical = dragVertical * bindSensibility;
    var bindHorizontal = dragHorizontal * bindSensibility;

    //clamping max value to maxBindAngle
    var angleVerticalClamped = bindVertical > maxBindAngleVertical ? maxBindAngleVertical : bindVertical;
    var angleHorizontalClamped = Mathf.Clamp(bindHorizontal, -maxBindAngleHorizontal, maxBindAngleHorizontal);

    transform.eulerAngles = new Vector3(-angleVerticalClamped, angleHorizontalClamped, transform.eulerAngles.z);
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



