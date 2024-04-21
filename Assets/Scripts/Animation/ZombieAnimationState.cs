using System;
using System.Collections;
using UnityEngine;

public class ZombieAnimationState : BasicAnimationState
{
    [SerializeField, Min(0)] private float _damageDelay;

    [SerializeField] private HitChecker _groundChecker;
    [SerializeField] private ZombieMovement _movement;
    [SerializeField] private Attacker _attacker;

    private Coroutine _coroutine;

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
        StopCoroutine();
        _coroutine = StartCoroutine(WaitBeforeCanWalk(_damageDelay));
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
        _movement.Speed;

    protected override void OnDie()
    {
        base.OnDie();
        StopCoroutine();
        Destroy(_movement);
    }

    protected override void SetAttackingParameterByBool()
    {
        if (IsGrounded == false || _coroutine != null)
            return;

        if (IsAttacking())
            _coroutine = StartCoroutine(WaitBeforeCanWalk(() => IsAttacking(), AttackDelay));

        base.SetAttackingParameterByBool();
    }

    private IEnumerator WaitBeforeCanWalk(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        DisableMovement();

        yield return wait;

        EnableMovement();

        _coroutine = null;
    }

    private IEnumerator WaitBeforeCanWalk(Func<bool> condition, float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        DisableMovement();

        while (condition.Invoke())
            yield return null;

        yield return wait;

        EnableMovement();

        _coroutine = null;
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void EnableMovement() =>
        _movement.enabled = true;

    private void DisableMovement() =>
        _movement.enabled = false;
}
