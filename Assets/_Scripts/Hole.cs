using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

  public static event Action OnTargetHit = delegate { };

  private void OnTriggerEnter(Collider other) => OnTargetHit();

}
