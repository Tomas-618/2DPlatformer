using UnityEngine;

public class FirstAidKit : Pickup<Health>
{
    protected override bool IsConditionTrueOnTriggerEnter(Collider2D collision, out Health behaviour) =>
        collision.TryGetComponent(out behaviour) && collision.GetComponent<Player>();

    protected override void DoActionOnTriggerEnter(Health behaviour)
    {
        int minIncreaseValue = 5;
        int maxIncreaseValue = 30;

        float increaseValue = Random.Range(minIncreaseValue, maxIncreaseValue + 1);

        behaviour.Increase(increaseValue);
    }
}
