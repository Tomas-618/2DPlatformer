using UnityEngine;

public abstract class HealthEventsHandler : MonoBehaviour
{
    [SerializeField, SerializeReference] private IReadOnlyHealthEvents _healthEvents;

    public IReadOnlyHealthEvents HealthEvents => _healthEvents;

    private void OnEnable()
    {
        _healthEvents.Died += OnDie;
        _healthEvents.Damaged += OnTakingDamage;
        _healthEvents.OnHealing += OnHealing;
    }

    private void OnDisable()
    {
        _healthEvents.Died -= OnDie;
        _healthEvents.Damaged -= OnTakingDamage;
        _healthEvents.OnHealing -= OnHealing;
    }

    protected virtual void OnDie() =>
        enabled = false;

    protected virtual void OnTakingDamage(float health) { }

    protected virtual void OnHealing(float health) { }
}
