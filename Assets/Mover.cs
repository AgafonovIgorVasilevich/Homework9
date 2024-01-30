using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed;

    private int _currentPosition = 0;
    private Vector3 _destination;

    private void Start()
    {
        _destination = _wayPoints[_currentPosition].position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == _destination)
        {
            _currentPosition = (_currentPosition + 1) % _wayPoints.Length;
            _destination = _wayPoints[_currentPosition].position;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, _speed * Time.deltaTime);
        }
    }
}