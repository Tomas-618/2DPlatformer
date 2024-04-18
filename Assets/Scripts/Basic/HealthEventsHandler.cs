using UnityEngine;

public abstract class HealthEventsHandler : MonoBehaviour
{
    [SerializeField] private HealthMediator _mediator;

    public HealthMediator Mediator => _mediator;

    public IReadOnlyHealthEvents Events => _mediator.HealthInfo;

    private void OnEnable()
    {
        Events.Died += OnDie;
        Events.Damaged += OnTakingDamage;
        Events.OnHealing += OnHealing;
    }

    private void OnDisable()
    {
        Events.Died -= OnDie;
        Events.Damaged -= OnTakingDamage;
        Events.OnHealing -= OnHealing;
    }

    protected virtual void OnDie() =>
        enabled = false;

    protected virtual void OnTakingDamage(float health) { }

    protected virtual void OnHealing(float health) { }
}
