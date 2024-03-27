using UnityEngine;

public class FirstAidKit : Pickup<Health>
{
    protected override bool IsConditionTrue(Collider2D collision, out Health behaviour) =>
        collision.TryGetComponent(out behaviour) && collision.GetComponent<Player>();

    protected override void DoSomething(Health behaviour)
    {
        int minIncreaseValue = 5;
        int maxIncreaseValue = 30;

        float increaseValue = Random.Range(minIncreaseValue, maxIncreaseValue);

        behaviour.Increase(increaseValue);
    }
}
