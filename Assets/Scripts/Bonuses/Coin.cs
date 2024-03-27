using UnityEngine;

public class Coin : Pickup
{
    protected override bool IsConditionTrue(Collider2D collision) =>
        collision.GetComponent<Player>();
}
