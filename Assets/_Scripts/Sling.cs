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


  [Header("Line Path")]
  [SerializeField] private LineRenderer lineVisual;
  [SerializeField] private int lineSegment = 10;
  [SerializeField] private Transform targetingPoint;
  private ThrowObject throwItem;
  [SerializeField] private int throwPower = 20;

  #endregion

  #region Unity functions

  //register to throwable object events
  private void OnEnable()
  {
    ThrowObject.OnLaunched += Launch;
    ThrowObject.OnDrag += RotateAndShowPath;
  }

  //unregister from throwable object events
  private void OnDisable()
  {
    ThrowObject.OnLaunched -= Launch;
    ThrowObject.OnDrag -= RotateAndShowPath;
  }
  private void Start()
  {
    lineVisual.positionCount = lineSegment;
    throwItem = objectContainer.GetTopObject();
  }
  #endregion

  #region functions

  private void Launch()
  {
    throwItem.gameObject.transform.parent = null;
    throwItem.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    throwItem.gameObject.GetComponent<Rigidbody>().velocity = throwItem.gameObject.transform.transform.forward * throwPower;
    VibrationAnimToOriginalPosAfterLaunch();
    objectContainer.PrepareTopObject();
    throwItem = null;
    lineVisual.enabled = false;
  }

  //Rotation of Sling while targeting
  private void RotateAndShowPath(Vector3 endDragPos, Vector3 startDragPos)
  {

    Rotate(endDragPos, startDragPos);
    DrawPath(endDragPos, startDragPos);
  }

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

  private void DrawPath(Vector3 endDragPos, Vector3 startDragPos)
  {
    if (throwItem == null)
      throwItem = objectContainer.GetTopObject();
    lineVisual.enabled = true;
    VisualizePath(throwItem.transform.forward * throwPower);
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

  private void VisualizePath(Vector3 vo)
  {
    for (int i = 0; i < lineSegment; i++)
    {
      Vector3 pos = CalculatePositionInTime(vo, i / (float)lineSegment);
      lineVisual.SetPosition(i, pos);
    }
  }
  private Vector3 CalculatePositionInTime(Vector3 initialVelocity, float time)
  {
    Vector3 Vxz = initialVelocity;
    Vxz.y = 0f;

    //  yatay mesafe= (baslangic hizi X zaman + ilk mesafe)  
    Vector3 distance = throwItem.gameObject.transform.position + initialVelocity * time;

    //dikey mesafe = (-1/2 * ivme * zamanin karesi) + (ilk hiz * zaman)+ ilk yukseklik   

    float verticalDistance = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (initialVelocity.y * time) + throwItem.gameObject.transform.position.y;

    distance.y = verticalDistance;

    return distance;

  }
  #endregion
}



