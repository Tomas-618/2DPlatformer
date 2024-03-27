using UnityEngine;

[RequireComponent( typeof(FootStepsSound))]
public class MovementSound : MonoBehaviour
{
    private FootStepsSound _footStepsSound;

    [SerializeField] private HitChecker _groundChecker;

    public bool IsGrounded => _groundChecker.HitInfo;

    private void Awake() =>
        _footStepsSound = GetComponent<FootStepsSound>();

    public void Play(in bool isRunning, in bool isStanding)
    {
        if (isStanding || IsGrounded == false)
        {
            _footStepsSound.Stop();

            return;
        }

        _footStepsSound.SetPitch(isRunning);
        _footStepsSound.Play();
    }
}
