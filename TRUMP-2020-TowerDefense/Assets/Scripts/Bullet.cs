using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform _target;

    public float speed = 50f;

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
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {

            // hit target and destroy this bullet
            HitTarget(); 
            return;

        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        // instantiate particle system, that lasts for 2 second and is destoyed by this time
        GameObject effect = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);

        Destroy(effect.gameObject, 2f);
        Destroy(_target.gameObject);
        Destroy(gameObject);
    }


}
