using UnityEngine;

[RequireComponent(typeof(Physics2DOwner))]
public class PlayerBounce : HealthEventsHandler
{
    [SerializeField, Min(0)] private float _jumpForce;

    [SerializeField] private HitChecker _groundChecker;

    private Physics2DOwner _physics2DOwner;

    public bool IsGrounded => _groundChecker.HitInfo;

    private void Reset() =>
        _jumpForce = 6;

    private void Awake() =>
        _physics2DOwner = GetComponent<Physics2DOwner>();

    private void Update() =>
        Jump();

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded)
            _physics2DOwner.Rigidbody2DInfo.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
    }
}
