using AYellowpaper;
using UnityEngine;

public abstract class HealthEventsHandler : MonoBehaviour
{
    [SerializeField] private InterfaceReference<IReadOnlyHealthEvents, MonoBehaviour> _events;

    public IReadOnlyHealthEvents Events => _events.Value;

    private void OnEnable()
    {
        Events.Died += OnDie;
        Events.Damaged += OnTakingDamage;
        Events.OnHealing += OnHealing;
    }

    private void OnDisable()
    {
        if (Events == null)
            return;

        Events.Died -= OnDie;
        Events.Damaged -= OnTakingDamage;
        Events.OnHealing -= OnHealing;
    }

    protected virtual void OnDie() =>
        enabled = false;

    protected virtual void OnTakingDamage(float health) { }

    protected virtual void OnHealing(float health) { }
}
