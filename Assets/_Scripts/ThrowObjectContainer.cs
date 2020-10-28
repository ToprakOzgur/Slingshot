using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjectContainer : MonoBehaviour
{
  [SerializeField] private List<ThrowObject> objectList;
  private List<Vector3> objectPositions = new List<Vector3>();


  private void Awake()
  {
    for (int i = 0; i < objectList.Count; i++)
    {
      objectPositions.Add(objectList[i].transform.localPosition);
    }
  }

  public ThrowObject GetTopObject()
  {
    ThrowObject item = objectList[0];
    objectList.RemoveAt(0);
    return item;
  }


  public void PrepareTopObject() => StartCoroutine(MoveUp());

  IEnumerator MoveUp()
  {
    yield return new WaitForSeconds(.5f);
    for (int i = 0; i < objectList.Count; i++)
    {
      objectList[i].transform.localPosition = new Vector3(objectPositions[i].x, objectPositions[i].y, objectPositions[i].z);
    }
    yield return new WaitForEndOfFrame();

    if (objectList.Count > 0)
      objectList[0].gameObject.GetComponent<Rigidbody>().isKinematic = false;
  }
}
