using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ZombieAnimationState : MonoBehaviour
{
    [SerializeField] private HitChecker _groundChecker;

    private Animator _animator;

    public bool IsGrounded => _groundChecker.HitInfo;

    private void Awake() =>
        _animator = GetComponent<Animator>();

    private void Update() =>
        SetGroundingParameter();

    private void SetGroundingParameter() =>
        _animator.SetBool(ZombieAnimatorParams.IsGrounded, IsGrounded);
}
