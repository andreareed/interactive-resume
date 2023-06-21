using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
  [SerializeField] Transform[] waypoints;
  [SerializeField] float speed = .5f;
  private int currentWaypointIndex = 0;

  void Update()
  {
    if (currentWaypointIndex < waypoints.Length)
    {
      Vector2 target = waypoints[currentWaypointIndex].position;
      transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

      if (Vector2.Distance(transform.position, target) < 0.01f)
      {
        currentWaypointIndex++;
        if (currentWaypointIndex > waypoints.Length - 1)
        {
          currentWaypointIndex = 0;
        }
      }
    }
  }
}
