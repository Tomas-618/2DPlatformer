using UnityEngine;

public class PlayerAnimatorParams
{
    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
    public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
}
