using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Zombie : MonoBehaviour
{
    [SerializeField, Min(0)] private float _speed;

    [SerializeField] private ArrivePoint[] _arrivePoints;
    [SerializeField] private ZombieSprite _sprite;

    private Rigidbody2D _rigidbody2D;
    private int _currentArrivePointIndex;

    public IReadOnlyList<Transform> ArrivePointsPositions => _arrivePoints
        .Select(arrivePoint => arrivePoint.transform)
        .ToList();

    private void Awake() =>
        _rigidbody2D = GetComponent<Rigidbody2D>();

    private void Start() =>
        _sprite.SetTarget(ArrivePointsPositions[_currentArrivePointIndex].position);

    private void FixedUpdate() =>
        Move();

    private void Move()
    {
        if (_arrivePoints[_currentArrivePointIndex].IsReached)
        {
            _currentArrivePointIndex = (_currentArrivePointIndex + 1) % _arrivePoints.Length;
            _sprite.SetTarget(ArrivePointsPositions[_currentArrivePointIndex].position);
        }

        Vector2 currentPointPosition = ArrivePointsPositions[_currentArrivePointIndex].position;

        _rigidbody2D.position = Vector2.MoveTowards(_rigidbody2D.position, currentPointPosition, _speed * Time.deltaTime);
    }
}
