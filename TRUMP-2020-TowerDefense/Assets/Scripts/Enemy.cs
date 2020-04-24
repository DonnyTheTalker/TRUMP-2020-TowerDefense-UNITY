using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Speed = 10f;

    // next way point, last one - is finish by what this object gets destroyed
    private Transform _target;
    private int _iWayPoint = 0;

    void Start()
    {
        _target = WayPoints.Points[0];
        _iWayPoint = 0;
    }

    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(_target.position, transform.position) <= 0.2f)
            GetNextWayPoint();

    }

    void GetNextWayPoint()
    {
        // last way point (the end) is achieved - we can destroy object
        // and deal damage to player
        if (_iWayPoint + 1 == WayPoints.Points.Length) {

            Destroy(gameObject);
            PlayerStats.GetDamage();

            return;

        }

        _target = WayPoints.Points[++_iWayPoint];


    }

}
