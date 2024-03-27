using UnityEngine;

public class ZombieAnimatorParams
{
    public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
    public static readonly int Damaged = Animator.StringToHash(nameof(Damaged));
    public static readonly int Died = Animator.StringToHash(nameof(Died));
    public static readonly int Speed = Animator.StringToHash(nameof(Speed));
    public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
}
