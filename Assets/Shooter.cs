using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private float _velocity;
    [SerializeField] float _timeDelay;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        WaitForSeconds delay = new WaitForSeconds(_timeDelay);
        bool isWork = true;
        Vector3 direction;

        while (isWork)
        {
            Rigidbody bullet = Instantiate(_bullet, _firePoint.position, Quaternion.identity);

            direction = (_firePoint.position - transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = direction * _velocity;

            yield return new WaitForSeconds(_timeDelay);
        }
    }
}