using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationState : BasicAnimationState
{
    [SerializeField] private PlayerMovement _movement;

    private bool _canAttack;

    private void Start() =>
        _canAttack = true;

    protected override void Update()
    {
        base.Update();
        SetAttackingParameterByTrigger();
        SetMovingParams();
    }

    protected override int SetDieTrigger() =>
        PlayerAnimatorParams.Died;

    protected override int SetDamageTrigger() =>
        PlayerAnimatorParams.Damaged;

    protected override int SetGroundingBool() =>
        PlayerAnimatorParams.IsGrounded;

    protected override bool IsGrounding() =>
        _movement.IsGrounded;

    protected override int SetAttackingTrigger() =>
        PlayerAnimatorParams.Attacked;

    protected override int SetMovingFloat() =>
        PlayerAnimatorParams.Speed;

    protected override float GetSpeed() =>
        _movement.Speed;

    protected override int SetMovingBool() =>
        PlayerAnimatorParams.IsMoving;

    protected override bool IsMoving() =>
        Input.GetAxisRaw(AxisNames.Horizontal) != 0;

    protected override void SetAttackingParameterByTrigger()
    {
        if (_movement.IsGrounded && _canAttack)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                base.SetAttackingParameterByTrigger();
                StartCoroutine(WaitBeforeCanAttack(AttackDelay));
            }
        }
    }

    private IEnumerator WaitBeforeCanAttack(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        _canAttack = false;

        yield return wait;

        _canAttack = true;
    }
}
