using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Physics2DOwner))]
public class ZombieMovement : MonoBehaviour
{
    [SerializeField, Min(0)] private float _walkingSpeed;
    [SerializeField, Min(0)] private float _runningSpeed;

    [SerializeField] private ArrivePoint[] _arrivePoints;
    [SerializeField] private FieldOfView _view;
    [SerializeField] private ZombieSprite _sprite;

    private Physics2DOwner _physics2DOwner;
    private int _currentArrivePointIndex;

    public IReadOnlyList<Transform> ArrivePointsPositions => _arrivePoints
        .Select(arrivePoint => arrivePoint.transform)
        .ToList();

    public float Speed { get; private set; }

    public bool IsStanding { get; private set; }

    public bool IsRunning => Speed == _runningSpeed;

    private void Awake() =>
        _physics2DOwner = GetComponent<Physics2DOwner>();

    private void OnDisable() =>
        _physics2DOwner.Rigidbody2DInfo.velocity = Vector2.zero;

    private void Start() =>
        _sprite.SetTarget(ArrivePointsPositions[_currentArrivePointIndex].position);

    private void FixedUpdate()
    {
        if (_view.IsSeeTarget)
        {
            Speed = _runningSpeed;
            MoveToTarget(_view.HitInfo.transform.position, Speed);

            return;
        }

        Speed = _walkingSpeed;
        MoveToCurrentArrivePoint(Speed);
    }

    private void MoveToTarget(in Vector2 position, in float speed) =>
        Move(position, speed);

    private void MoveToCurrentArrivePoint(in float speed)
    {
        if (_arrivePoints[_currentArrivePointIndex].IsReached)
            _currentArrivePointIndex = (_currentArrivePointIndex + 1) % _arrivePoints.Length;

        Vector2 currentPointPosition = ArrivePointsPositions[_currentArrivePointIndex].position;

        Move(currentPointPosition, speed);
    }

    private void Move(in Vector2 position, in float speed)
    {
        IsStanding = _physics2DOwner.Rigidbody2DInfo.position == position;

        _sprite.SetTarget(position);
        _physics2DOwner.Rigidbody2DInfo.position = Vector2.MoveTowards(_physics2DOwner.Rigidbody2DInfo.position,
            position, speed * Time.deltaTime);
    }
}
