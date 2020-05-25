using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
  public float moveSpeed = 2;
  [Range(0f, 1f)]
  public float joiningThreshold = 0.5f;

  [SerializeField]
  private Vector3 targetPosition;
  private bool shouldMove = false;
  private Queue queue;

  private void Start()
  {
    queue = GameObject.Find("queue").GetComponent<Queue>();

    if (ShouldQueue())
    {
      queue.Join(this);
    }
  }

  private void Update()
  {
    if (shouldMove)
    {
      Vector3 direction = (targetPosition - transform.position);
      direction.Normalize();

      transform.Translate(direction * moveSpeed * Time.deltaTime);

      if (Vector3.Distance(targetPosition, transform.position) < 0.1f)
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

  private bool ShouldQueue()
  {
    if (Random.Range(0f, 1f) > joiningThreshold)
    {
      return true;
    }
    return false;
  }
}
