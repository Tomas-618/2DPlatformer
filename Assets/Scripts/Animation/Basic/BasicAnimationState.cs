using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class BasicAnimationState : HealthEventsHandler
{
    [SerializeField, Min(0)] private float _attackDelay;

    private Animator _animator;

    public float AttackDelay => _attackDelay;

    private void Awake() =>
        _animator = GetComponent<Animator>();

    protected virtual void Reset() =>
        _attackDelay = 0.8f;

    protected virtual void Update() =>
        SetGroundingParameter();

    public void SetDieParameter() =>
        _animator.SetTrigger(SetDieTrigger());

    public virtual void SetDamageParameter() =>
        _animator.SetTrigger(SetDamageTrigger());

    protected abstract int SetDieTrigger();

    protected abstract int SetDamageTrigger();

    protected abstract int SetGroundingBool();

    protected abstract int SetMovingFloat();

    protected abstract bool IsGrounding();

    protected abstract float GetSpeed();

    protected virtual int SetAttackingTrigger() =>
        0;

    protected virtual int SetAttackingBool() =>
        0;

    protected virtual int SetMovingBool() =>
        0;

    protected virtual bool IsMoving() =>
        false;

    protected virtual bool IsAttacking() =>
        false;

    protected virtual void SetAttackingParameterByTrigger() =>
        _animator.SetTrigger(SetAttackingTrigger());

    protected virtual void SetAttackingParameterByBool() =>
        _animator.SetBool(SetAttackingBool(), IsAttacking());

    protected void SetMovingParams()
    {
        _animator.SetBool(SetMovingBool(), IsMoving());
        SetMovingParameter();
    }

    protected void SetMovingParameter() =>
        _animator.SetFloat(SetMovingFloat(), GetSpeed());

    protected override void OnDie()
    {
        SetDieParameter();
        base.OnDie();
    }

    protected override void OnTakingDamage(float health) =>
        SetDamageParameter();

    private void SetGroundingParameter() =>
        _animator.SetBool(SetGroundingBool(), IsGrounding());
}
