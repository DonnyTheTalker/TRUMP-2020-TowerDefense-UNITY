using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float Speed = 10f;
    public int Health = 100;
    private int _maxHealth;
    public int Profit = 5;

    // next way point, last one - is finish by what this object gets destroyed
    private Transform _target;
    private int _iWayPoint = 0;

    public ParticleSystem DeathEffect;

    public Image HealthBar;

    void Start()
    {
        _maxHealth = Health;
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
        HealthBar.fillAmount = Mathf.Max(0f, (float)Health) / _maxHealth;

        if (Health <= 0)
            Die();

    }

    void Die()
    {
        ParticleSystem effect = (ParticleSystem)Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(effect.gameObject, 2f);

        PlayerStats.Money += Profit;
        Destroy(gameObject);

    }

}
