using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform _target;

    public float Speed = 50f;
    public float RotationSpeed = 10f;
    public float ExplosionRadius = 0f;

    // basically, just a particle system used to smooth out an enemy hit
    public GameObject ImpactEffect;

    public void SetTarget(Transform target)
    {
        _target = target;    
    }

    void Update()
    {
        if (_target == null) {

            // our target can be destroyed regardless of our bullet 
            // other bullet or hitting the end spot

            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {

            // hit target and destroy this bullet
            HitTarget(); 
            return;

        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        
        // smooth change of bullet rotation - is important for rockets
        dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    void HitTarget()
    {
        // instantiate particle system, that lasts for 2 second and is destoyed by this time
        GameObject effect = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effect.gameObject, 2f);

        if (ExplosionRadius > 0f) {

            Explode();

        } else {

            Damage(_target);

        }
        
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] objectsHit = Physics.OverlapSphere(transform.position, ExplosionRadius);

        foreach (Collider collider in objectsHit) {

            if (collider.tag == "Enemy") {
                Damage(collider.transform);
            }

        }

    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
        
    }

}
