using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

  public static event Action OnTargetHit = delegate { };

  [Header("MOVEMENT SETTINGS")]
  [SerializeField] private bool isMoveable = true;
  [SerializeField] private float moveSpeed = 2.0f;
  [SerializeField] private float closeThreshold = 0.2f;
  [SerializeField] private float waitDelay = 2.0f;
  [SerializeField] private Transform[] movePoints;

  private Vector3 targetPos = Vector3.zero;
  private void OnTriggerEnter(Collider other) => OnTargetHit();

  IEnumerator Start()
  {
    if (!isMoveable)
      yield return null;

    while (true)
    {
      targetPos = transform.position;
      // do not move
      yield return new WaitForSeconds(waitDelay);
      // choose new location
      targetPos = movePoints[UnityEngine.Random.Range(0, movePoints.Length)].position;
      // wait until we arrive
      while ((transform.position - targetPos).magnitude > closeThreshold)
      {
        yield return null;
      }
    }
  }
  void Update()
  {
    if (!isMoveable)
      return;

    if ((transform.position - targetPos).magnitude > closeThreshold)
    {
      transform.position += (targetPos - transform.position).normalized * moveSpeed * Time.deltaTime;
    }
  }
}
