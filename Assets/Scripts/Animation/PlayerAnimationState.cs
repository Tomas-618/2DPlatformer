using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationState : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;

    private Animator _animator;
    
    private void Awake() =>
        _animator = GetComponent<Animator>();

    private void Update()
    {
        SetMovingParams();
        SetGroundingParameter();
    }

    private void SetGroundingParameter() =>
        _animator.SetBool(PlayerAnimatorParams.IsGrounded, _movement.IsGrounded);

    private void SetMovingParams()
    {
        _animator.SetBool(PlayerAnimatorParams.IsMoving, Input.GetAxisRaw(AxisNames.Horizontal) != 0);
        _animator.SetFloat(PlayerAnimatorParams.Speed, _movement.Speed);
    }
}
