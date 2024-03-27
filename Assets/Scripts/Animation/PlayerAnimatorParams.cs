using UnityEngine;

public class PlayerAnimatorParams
{
    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsMoving = Animator.StringToHash(nameof(IsMoving));
    public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
    public static readonly int Damaged = Animator.StringToHash(nameof(Damaged));
    public static readonly int Died = Animator.StringToHash(nameof(Died));
    public static readonly int Attacked = Animator.StringToHash(nameof(Attacked));
}
