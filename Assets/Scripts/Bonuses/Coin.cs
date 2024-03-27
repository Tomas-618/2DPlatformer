using UnityEngine;

public class Coin : Pickup
{
    protected override bool IsConditionTrueOnTriggerEnter(Collider2D collision) =>
        collision.GetComponent<Player>();
}
