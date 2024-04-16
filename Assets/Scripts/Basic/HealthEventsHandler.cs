using UnityEngine;

public abstract class HealthEventsHandler : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Died += OnDie;
        _health.Damaged += OnTakingDamage;
        _health.OnHealing += OnHealing;
    }

    private void OnDisable()
    {
        _health.Died -= OnDie;
    }

    protected virtual void OnDie() =>
        enabled = false;

    protected virtual void OnTakingDamage(float health) { }

    protected virtual void OnHealing(float health) { }
}
