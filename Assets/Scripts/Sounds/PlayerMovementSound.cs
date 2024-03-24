using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(FootStepsSound))]
public class PlayerMovementSound : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private FootStepsSound _footStepsSound;

    [SerializeField] private HitChecker _groundChecker;

    public bool IsGrounded => _groundChecker.HitInfo;

    public bool IsMute => _rigidbody2D.velocity == Vector2.zero || IsGrounded == false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _footStepsSound = GetComponent<FootStepsSound>();
    }

    private void Update()
    {
        if (IsMute)
        {
            _footStepsSound.Stop();

            return;
        }

        _footStepsSound.SetPitch(Input.GetKey(KeyCode.LeftShift));
        _footStepsSound.Play();
    }
}
