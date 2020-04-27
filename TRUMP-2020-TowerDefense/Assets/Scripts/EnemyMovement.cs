using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    // next way point, last one - is finish by what this object gets destroyed
    private Transform _target;
    private int _iWayPoint = 0;

    private Enemy _enemy;

    void Start()
    { 
        _target = WayPoints.Points[0];
        _iWayPoint = 0;
        _enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _enemy.Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(_target.position, transform.position) <= 0.2f)
            GetNextWayPoint();

        _enemy.Speed = _enemy._maxSpeed;
    }


    void GetNextWayPoint()
    {
        // last way point (the end) is achieved - we can destroy object
        // and deal damage to player
        if (_iWayPoint + 1 == WayPoints.Points.Length) {

            Destroy(gameObject);
            PlayerStats.TakeDamage();

            return;

        }

        _target = WayPoints.Points[++_iWayPoint];

    }

}
