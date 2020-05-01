using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float Speed = 10f;
    [HideInInspector]
    public float _maxSpeed;
    public float Health = 100f;
    private float _maxHealth;
    public int Profit = 10; 

    public ParticleSystem DeathEffect;

    public Image HealthBar;

    void Start()
    {
        _maxHealth = Health;
        _maxSpeed = Speed;
    } 

    public void TakeDamage(float amount)
    {

        Health -= amount;
        HealthBar.fillAmount = Mathf.Max(0f, (float)Health) / _maxHealth;

        if (Health <= 0)
            Die();

    }

    void Die()
    {

        WaveSpawner.EnemiesAlive--;

        ParticleSystem effect = (ParticleSystem)Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(effect.gameObject, 2f);

        PlayerStats.Money += Profit;
        Destroy(gameObject);

    }

    public void Slow(float slowPercentage)
    {
        Speed = _maxSpeed * (1f - slowPercentage);
    }

}
