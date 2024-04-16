using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ZombieAnimationState : BasicAnimationState
{
    [SerializeField, Min(0)] private float _damageDelay;

    [SerializeField] private HitChecker _groundChecker;
    [SerializeField] private ZombieMovement _entity;
    [SerializeField] private Attacker _attacker;

    private float _currentAttackDelay;

    public bool IsGrounded => _groundChecker.HitInfo;

    protected override void Reset()
    {
        base.Reset();
        _damageDelay = 0.6f;
    }

    protected override void Update()
    {
        base.Update();
        SetAttackingParameterByBool();
        SetMovingParameter();
    }

    public override void SetDamageParameter()
    {
        base.SetDamageParameter();
        StartCoroutine(WaitBeforeCanWalk(_damageDelay));
    }

    protected override int SetDieTrigger() =>
        ZombieAnimatorParams.Died;

    protected override int SetDamageTrigger() =>
        PlayerAnimatorParams.Damaged;

    protected override int SetGroundingBool() =>
        ZombieAnimatorParams.IsGrounded;

    protected override bool IsGrounding() =>
        IsGrounded;

    protected override int SetAttackingBool() =>
        ZombieAnimatorParams.IsAttack;

    protected override bool IsAttacking() =>
        _attacker.HitInfo;

    protected override int SetMovingFloat() =>
        ZombieAnimatorParams.Speed;

    protected override float GetSpeed() =>
        _entity.Speed;

    protected override void SetAttackingParameterByBool()
    {
        if (IsGrounded)
        {
            base.SetAttackingParameterByBool();

            if (_attacker.HitInfo)
            {
                _currentAttackDelay = AttackDelay;
                _entity.enabled = false;

                return;
            }

            _currentAttackDelay -= Time.deltaTime;
            _currentAttackDelay = Mathf.Clamp(_currentAttackDelay, 0, AttackDelay);

            if (_currentAttackDelay <= 0)
                _entity.enabled = true;
        }
    }

    private IEnumerator WaitBeforeCanWalk(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        _entity.enabled = false;

        yield return wait;

        _entity.enabled = true;
    }
}
