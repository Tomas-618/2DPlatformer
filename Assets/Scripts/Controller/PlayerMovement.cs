using UnityEngine;

[RequireComponent(typeof(Physics2DOwner))]
public class PlayerMovement : HealthEventsHandler
{
    [SerializeField, Min(0)] private float _moveSpeed;
    [SerializeField, Min(0)] private float _runSpeed;

    [SerializeField] private HitChecker _groundChecker;
    [SerializeField] private ObstacleChecker _obstacleChecker;

    private Physics2DOwner _physics2DOwner;

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
        _physics2DOwner = GetComponent<Physics2DOwner>();

    public void OnDisable() =>
        _physics2DOwner.Rigidbody2DInfo.velocity = Vector2.zero;

    private void FixedUpdate() =>
        Move();

    private void Move()
    {
        Vector2 velocity = _physics2DOwner.Rigidbody2DInfo.velocity;

        velocity.x = Input.GetAxisRaw(AxisNames.Horizontal) * Speed;

        Vector2 direction = velocity.normalized;

        if (_obstacleChecker.IsWayFree(direction) == false)
        {
            if (IsGrounded == false || _obstacleChecker.HitInfo.rigidbody == false)
            {
                return;
            }
        }

        _physics2DOwner.Rigidbody2DInfo.velocity = velocity;
    }
}
