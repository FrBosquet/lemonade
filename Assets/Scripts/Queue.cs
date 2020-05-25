using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
  public Vector3 offset;
  public List<Customer> customers;

  private void UpdatePositions()
  {
    for (int i = 0; i < customers.Count; i++)
    {
      Customer customer = customers[i];
      customer.SetTargetPosition(transform.position + offset * i);
    }
  }

  public void Join(Customer customer)
  {
    for (int i = 0; i <= customers.Count; i++)
    {
      if (i == customers.Count)
      {
        customers.Add(customer);
        break;
      }

      Customer other = customers[i];

      float otherDist = (other.transform.position - transform.position).magnitude;
      float distance = (customer.transform.position - transform.position).magnitude;

      if (distance < otherDist)
      {
        customers.Insert(i, customer);
        break;
      }
    }

    UpdatePositions();
  }
}
