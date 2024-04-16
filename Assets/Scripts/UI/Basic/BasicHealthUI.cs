using UnityEngine;

public abstract class BasicHealthUI : HealthEventsHandler
{
    protected override void OnDie() =>
        SetValue(0);

    protected override void OnTakingDamage(float health) =>
        SetValue(health);

    protected override void OnHealing(float health) =>
        SetValue(health);

    protected abstract void SetValue(float value);
}
