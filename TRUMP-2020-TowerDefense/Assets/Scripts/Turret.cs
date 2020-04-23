using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform _target;

    [Header("Attributes")]

    public float Range = 15f; 
    public float FireRate = 1f;
    private float _fireCountdown = 0;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform RotatingPart;
    public float RotationSpeed = 10f;

    public GameObject BulletPrefab;
    public Transform FirePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
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

        } else {

            _target = null;

        }

    }

    void Update()
    {
        if (_target != null) {

            // we can use quaternion for smooth turret's head movement
            Vector3 dir = _target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(RotatingPart.rotation, lookRotation, Time.deltaTime * RotationSpeed).eulerAngles;
            RotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            _fireCountdown -= Time.deltaTime;

            if (_fireCountdown <= 0) {

                _fireCountdown = 1f / FireRate;
                Shoot();

            }

        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.SetTarget(_target);

        Debug.Log("Умри, собака");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);   
    }

}
