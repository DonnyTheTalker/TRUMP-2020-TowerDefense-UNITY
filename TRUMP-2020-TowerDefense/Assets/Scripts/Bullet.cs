using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform _target;

    public float speed = 50f;

    public GameObject ImpactEffect;

    public void SetTarget(Transform target)
    {
        _target = target;    
    }

    void Update()
    {
        if (_target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {

            HitTarget(); 
            return;

        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);

        Destroy(effect.gameObject, 2f);
        Destroy(_target.gameObject);
        Destroy(gameObject);
    }


}
