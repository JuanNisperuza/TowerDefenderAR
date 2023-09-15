using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 0.4f;
    private Transform target;
    private int wayPointIndex = 0;

    private void Start()
    {
        target = WayPoints.points[0];
        movementSpeed = GameManager.Instance.scenaryGO.transform.localScale.x * movementSpeed;
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.LookAt(target.position);
        transform.Translate(direction.normalized * movementSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.02f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if (wayPointIndex >= WayPoints.points.Length - 1)
        {
            GameManager.Instance.Life -= 10;
            Destroy(gameObject);
            return;
        }
        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }
}
