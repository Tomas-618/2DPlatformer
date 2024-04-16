using UnityEngine;

public abstract class HealthEventsHandler : MonoBehaviour
{
    [SerializeField] private Health _model;

    public Health Model => _model;

    private void OnEnable()
    {
        _model.Died += OnDie;
        _model.Damaged += OnTakingDamage;
        _model.OnHealing += OnHealing;
    }

    private void OnDisable()
    {
        _model.Died -= OnDie;
        _model.Damaged -= OnTakingDamage;
        _model.OnHealing -= OnHealing;
    }

    protected virtual void OnDie() =>
        enabled = false;

    protected virtual void OnTakingDamage(float health) { }

    protected virtual void OnHealing(float health) { }
}
