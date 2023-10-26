using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMotion : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 4f;
    private void Update()
    {
        Vector3 waypointPosition = waypoints[currentWaypointIndex].transform.position;
        Vector3 platformPosition = transform.position;
        if (Vector2.Distance(waypointPosition, platformPosition) < 0.1f )
        {
            currentWaypointIndex++;
            if ( currentWaypointIndex >= waypoints.Length ) { currentWaypointIndex = 0; }
        }

        transform.position = Vector2.MoveTowards(platformPosition, waypointPosition, Time.deltaTime * speed);
    }
}
