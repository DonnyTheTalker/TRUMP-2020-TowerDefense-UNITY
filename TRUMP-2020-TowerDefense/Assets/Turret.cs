using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform _target;

    public float Range = 15f;
    public float RotationSpeed = 10f;

    public string enemyTag = "Enemy";

    public Transform RotatingPart;

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

            Vector3 dir = _target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(RotatingPart.rotation, lookRotation, Time.deltaTime * RotationSpeed).eulerAngles;
            RotatingPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);   
    }

}
