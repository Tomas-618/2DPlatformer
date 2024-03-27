using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBounce : MonoBehaviour
{
    [SerializeField, Min(0)] private float _jumpForce;

    [SerializeField] private HitChecker _groundChecker;

    private Rigidbody2D _rigidbody2D;

    public bool IsGrounded => _groundChecker.HitInfo;

    private void Reset() =>
        _jumpForce = 6;

    private void Awake() =>
        _rigidbody2D = GetComponent<Rigidbody2D>();

    private void Update() =>
        Jump();

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded)
            _rigidbody2D.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
    }
}
