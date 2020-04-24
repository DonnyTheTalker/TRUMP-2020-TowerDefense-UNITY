using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Speed = 10f;

    // next way point, last one - is finish by what this object gets destroyed
    private Transform _target;
    private int _iWayPoint = 0;

    public int Health = 100;
    public int Profit = 5;

    public ParticleSystem DeathEffect;

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
            PlayerStats.TakeDamage();

            return;

        }

        _target = WayPoints.Points[++_iWayPoint]; 

    }

    public void TakeDamage(int amount)
    {

        Health -= amount;

        if (Health <= 0)
            Die();

    }

    void Die()
    {
        ParticleSystem effect = (ParticleSystem)Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

        PlayerStats.Money += Profit;
        Destroy(gameObject);

    }

}
