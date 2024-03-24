using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(0)] private float _moveSpeed;
    [SerializeField, Min(0)] private float _runSpeed;

    [SerializeField] private HitChecker _groundChecker;
    [SerializeField] private ObstacleChecker _obstacleChecker;

    private Rigidbody2D _rigidbody2D;

    public Vector2 Velocity => _rigidbody2D.velocity;

    public float Speed => Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _moveSpeed;

    public bool IsGrounded => _groundChecker.HitInfo;

    private void Reset()
    {
        _moveSpeed = 5;
        _runSpeed = 10;
    }

    private void OnValidate()
    {
        if (_moveSpeed >= _runSpeed)
            _runSpeed = _moveSpeed + 1;
    }

    private void Awake() =>
        _rigidbody2D = GetComponent<Rigidbody2D>();

    private void FixedUpdate() =>
        Move();

    private void Move()
    {
        Vector2 velocity = _rigidbody2D.velocity;

        velocity.x = Input.GetAxisRaw(AxisNames.Horizontal) * Speed;

        Vector2 direction = velocity.normalized;

        if (_obstacleChecker.IsWayFree(direction) == false)
        {
            if (IsGrounded == false || _obstacleChecker.HitInfo.rigidbody == false)
            {
                return;
            }
        }

        _rigidbody2D.velocity = velocity;
    }
}
