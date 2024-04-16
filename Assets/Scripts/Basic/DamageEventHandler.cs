using UnityEngine;

public abstract class DamageEventHandler : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable() =>
        _health.Damaged += OnTakingDamage;

    private void OnDisable() =>
        _health.Damaged -= OnTakingDamage;

    protected abstract void OnTakingDamage(float health);
}
