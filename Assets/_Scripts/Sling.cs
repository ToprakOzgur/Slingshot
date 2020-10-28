using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{

  #region properties

  [Header("GamePlay Settings")]
  [SerializeField] [Range(0, 30)] private int maxRotateVertical;
  [SerializeField] [Range(0, 60)] private int maxRotateHorizontal;
  [SerializeField] private int rotationSensibility;
  [SerializeField] private float bounceOutAnimDuration;


  [Header("Reference to Gameobjects")]
  [SerializeField] private ThrowObjectContainer objectContainer;
  #endregion

  #region Unity functions

  //register to throwable object events
  private void OnEnable()
  {
    ThrowObject.OnLaunched += Launch;
    ThrowObject.OnDrag += Rotate;
  }

  //unregister from throwable object events
  private void OnDisable()
  {
    ThrowObject.OnLaunched -= Launch;
    ThrowObject.OnDrag -= Rotate;
  }

  #endregion

  #region functions

  private void Launch()
  {
    var throwItem = objectContainer.GetTopObject();
    throwItem.gameObject.transform.parent = null;
    throwItem.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    throwItem.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 20;
    VibrationAnimToOriginalPosAfterLaunch();
    objectContainer.PrepareTopObject();
  }

  //Rotation of Sling while targeting
  private void Rotate(Vector3 endDragPos, Vector3 startDragPos)
  {

    var dragAmount = startDragPos - endDragPos;

    if (dragAmount.y < 0) return;

    var rotateAngle = dragAmount * rotationSensibility;

    //Clamping angles
    var verticalRotationClamped = rotateAngle.y > maxRotateVertical ? maxRotateVertical : rotateAngle.y;
    var horizontalRotationClamped = Mathf.Clamp(rotateAngle.x, -maxRotateHorizontal, maxRotateHorizontal);

    //Rotation  
    transform.eulerAngles = new Vector3(-verticalRotationClamped, horizontalRotationClamped, transform.eulerAngles.z);
  }

  private void VibrationAnimToOriginalPosAfterLaunch()
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



