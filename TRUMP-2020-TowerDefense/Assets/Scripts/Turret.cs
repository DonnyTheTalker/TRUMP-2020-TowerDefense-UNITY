using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform _target;
    private Enemy _targetEnemy;

    [Header("Attributes")]

    public float Range = 15f; 
    public float FireRate = 1f;
    private float _fireCountdown = 0.1f;

    [Header("Optional Laser Attributes")]
    public bool IsLaser = false;
    
    public LineRenderer Laser;
    public ParticleSystem ImpactEffect;
    public Light ImpactLight;

    public int DamagePerSecond = 35;
    public float SlowPercentage = 0.3f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform RotatingPart;
    public float RotationSpeed = 10f;

    public GameObject BulletStorage;
    private float _reloadDelay;

    public GameObject BulletPrefab;
    public Transform FirePoint;

    void Start()
    {
        _reloadDelay = 1f / FireRate / 3f;
        InvokeRepeating("UpdateTarget", 0f, 0.5f); 

        if (IsLaser) {

            DisableLaser();
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) {

            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance) {

                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

            }

        }

        if (nearestEnemy != null && shortestDistance <= Range) {

            _target = nearestEnemy.transform;
            _targetEnemy = _target.GetComponent<Enemy>();

        } else {

            _target = null;

        }

    }

    void Update()
    {
        if (_target != null) {

            LockOnTarget();

            if (IsLaser) {

                UseLaser();

            } else {

                _fireCountdown -= Time.deltaTime;

                if (_fireCountdown <= 0) {

                    StartCoroutine(Reload());
                    _fireCountdown = 1f / FireRate;
                    Shoot();

                }
            }

        } else if (IsLaser && Laser.enabled) {

            DisableLaser();

        }
    }

    void LockOnTarget()
    {
        // we can use quaternion for smooth turret's head movement
        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(RotatingPart.rotation, lookRotation, Time.deltaTime * RotationSpeed).eulerAngles;
        RotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    void UseLaser()
    {
        _targetEnemy.TakeDamage(DamagePerSecond * Time.deltaTime);

        if (_target != null) {

            _targetEnemy.Slow(SlowPercentage);

            if (!Laser.enabled) {
                EnableLaser();
            }

            Laser.SetPosition(0, FirePoint.position);
            Laser.SetPosition(1, _target.position);

            Vector3 dir = FirePoint.position - _target.position;

            ImpactEffect.transform.position = _target.position + dir.normalized;

            ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
        } else {

            DisableLaser();

        }
    }

    void EnableLaser()
    {
        Laser.enabled = true;
        ImpactEffect.Play();
        ImpactLight.enabled = true;
    }

    void DisableLaser()
    {
        Laser.enabled = false;
        ImpactEffect.Stop();
        ImpactLight.enabled = false;
    }

    // upload new missile into missile launcher
    // using some trick
    IEnumerator Reload()
    {
        BulletStorage.SetActive(false);
        yield return new WaitForSeconds(_reloadDelay);
        BulletStorage.SetActive(true);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.SetTarget(_target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);   
    }

}
