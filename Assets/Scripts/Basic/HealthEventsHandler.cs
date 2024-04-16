using UnityEngine;

public abstract class HealthEventsHandler : MonoBehaviour
{
    [SerializeField] private IReadOnlyHealthEvents _events;

    public IReadOnlyHealthEvents Events => _events;

    private void OnEnable()
    {
        _events.Died += OnDie;
        _events.Damaged += OnTakingDamage;
        _events.OnHealing += OnHealing;
    }

    private void OnDisable()
    {
        _events.Died -= OnDie;
        _events.Damaged -= OnTakingDamage;
        _events.OnHealing -= OnHealing;
    }

    protected virtual void OnDie() =>
        enabled = false;

    protected virtual void OnTakingDamage(float health) { }

    protected virtual void OnHealing(float health) { }
}
