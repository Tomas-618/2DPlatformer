using System.Collections.Generic;
using UnityEngine;

public class HitCheckerByCollider2D : MonoBehaviour
{
    private readonly List<IDamagable> _targets = new List<IDamagable>();

    public List<IDamagable> Targets => _targets;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health) == false)
            return;

        if (collision.GetComponent<Zombie>() == false)
            return;

        _targets.Add(health);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health) == false)
            return;

        if (collision.GetComponent<Zombie>() == false)
            return;

        _targets.Remove(health);
    }
}
