using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costumer : MonoBehaviour
{
  public float moveSpeed = 1;

  private Vector3 targetPosition;
  private bool shouldMove = true;

  private void Update()
  {
    if (shouldMove)
    {
      Vector3 direction = (targetPosition - transform.position);
      direction.Normalize();

      transform.Translate(direction * moveSpeed * Time.deltaTime);

      if (Vector3.Distance(targetPosition, transform.position) < 0.5f)
      {
        shouldMove = false;
      }
    }
  }

  public void SetTargetPosition(Vector3 newPosition)
  {
    targetPosition = newPosition;
    shouldMove = true;
  }
}
