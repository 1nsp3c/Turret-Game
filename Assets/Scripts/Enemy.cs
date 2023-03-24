using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointindex = 0;
    private void Start()
    {
        target = Waypoints.wayPoints[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }
    public void GetNextWaypoint()
    {
        if(waypointindex >= Waypoints.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointindex++;
        target = Waypoints.wayPoints[waypointindex];
    }
}
