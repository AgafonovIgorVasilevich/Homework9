using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private float _timeBetweenShoots;
    [SerializeField] private float _velocity;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds delay = new WaitForSeconds(_timeBetweenShoots);
        bool isWork = true;
        Vector3 direction;
        Rigidbody bullet;

        while (isWork)
        {
            bullet = Instantiate(_bullet, _firePoint.position, Quaternion.identity);
            direction = (_firePoint.position - transform.position).normalized;
            bullet.velocity = direction * _velocity;
            yield return delay;
        }
    }
}